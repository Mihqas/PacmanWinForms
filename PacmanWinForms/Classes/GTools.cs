﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PacmanWinForms
{
    public static class GTools
    {

        public static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Pacman";
        public static string saveFile = savePath + "\\highScores.json";

        public static bool createFile(string saveFile, string contentToWrite)
        {
            try
            {
                using (System.IO.FileStream fs = System.IO.File.Create(saveFile))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }

                System.IO.File.WriteAllText(saveFile, contentToWrite);
                return true;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Create IO.File Error");
                return false;
            }
        }


        public static void loadHighScores(string savePath, string saveFile)
        {
            Directory.CreateDirectory(savePath);
            try
            {
                if (System.IO.File.Exists(saveFile))
                {
                    HighScoreList.hsList.Clear();
                    HighScoreList.hsList = JsonConvert.DeserializeObject<List<HighScores>>(System.IO.File.ReadAllText(saveFile));
                    HighScoreList.hsList = HighScoreList.hsList.OrderByDescending(p => p.score).ToList();
                }
                else
                {
                    GTools.createFile(saveFile, "[ ]");
                    loadHighScores(savePath, saveFile);
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Load User Error.\n");
            }
        }

        public static void saveHighScores(string saveFile)
        {
            try
            {
                string contentsToWriteToFile = JsonConvert.SerializeObject(HighScoreList.hsList.ToArray(), Formatting.Indented);

                System.IO.File.WriteAllText(saveFile, contentsToWriteToFile);

            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Save User Error.\n");
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            try
            {
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name, type);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }

            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Convert to DataTable Error");
               
                return null;
            }


        }

    }

}
