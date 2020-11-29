using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PacmanWinForms
{
    public static class MazeList
    {
        private static string roadInit()
        {
            string data = @"0000000000000000000000000000
0111111111111001111111111110
0100001000001001000001000010
0101101011101111011101011010
0100001000001001000001000010
0111111111111001111111111110
0100001001000000001001000010
0100001001000000001001000010
0111111001111001111001111110
0001001000001001000001001000
0001001000001001000001001000
0111001111111111111111001110
0100001001001111001001000010
0100001001011111101001000010
0111111001011111101001111110
0100001001011111101001000010
0100001001000000001001000010
0111001001111111111001001110
0001001001000000001001001000
0001001001000000001001001000
0111111111111111111111111110
0100001000001001000001000010
0100001000001001000001000010
0111001111111001111111001110
0001001001000000001001001000
0001001001000000001001001000
0111111001111001111001111110
0100001000001001000001000010
0100001000001001000001000010
0111111111111111111111111110
0000000000000000000000000000";
            return data;
        }

        private static string road2Init()
        {
            string data = @"0000000000000000000000000000
0111111111111001111111111110
0100001000001001000001000010
0101101011101001011101011010
0100001000001001000001000010
0111111111111111111111111110
0100001001000000001001000010
0100001001000000001001000010
0111111001111001111001111110
0000001000001001000001000000
1111101000001001000001011111
1111101001111111111001011111
1111101001001111001001011111
0000001001011111101001000000
1111111111011111101111111111
0000001001011111101001000000
1111101001000000001001011111
1111101001111111111001011111
1111101001000000001001011111
0000001001000000001001000000
0111111111111001111111111110
0100001000001001000001000010
0100001000001001000001000010
0111001111111111111111001110
0001001001000000001001001000
0001001001000000001001001000
0111111001111001111001111110
0100000000001001000000000010
0100000000001001000000000010
0111111111111111111111111110
0000000000000000000000000000";
            return data;
        }




        public static List<Point> WallList(int stage)
        {
            // hardwired data instead of reading from file (not feasible on web player)
            List<Point> wList = new List<Point>();
            string map = (stage == 1) ? roadInit() : road2Init();
            using (StringReader reader = new StringReader(map))
            {
                string line;
                int Y = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    for (int i = 0; i < line.Length; ++i)
                    {
                        if (line[i] == '0')
                        {
                            wList.Add(new Point(i, Y));
                        }
                    }
                    Y++;
                }
            }
            wList = wList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return wList;
        }

        public static List<Point> RoadList()
        {
            // hardwired data instead of reading from file (not feasible on web player)
            List<Point> wList = new List<Point>();
            using (StringReader reader = new StringReader(road2Init()))
            {
                string line;
                int Y = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    for (int i = 0; i < line.Length; ++i)
                    {
                        if (line[i] == '1')
                        {
                            wList.Add(new Point(i, Y));

                        }
                    }
                    Y++;
                }
            }

            return wList;
        }

        public static List<Point> wallPoints()
        {
            List<Point> pList = new List<Point>();
            return pList;
        }
    }

}
