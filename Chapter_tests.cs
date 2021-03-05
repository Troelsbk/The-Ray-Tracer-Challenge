using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    class Chaptor_4
    {
        public void draw_clock()
        {
            double PI = Math.PI;
            List<Point> point_list = new List<Point>();
            Matrix rot_pi_6 = Matrix.GetRotateZ(PI / 6);//make pi/6 rotation matrix
            Canvas canvas = new Canvas(111, 111);
            //translations matrix
            Matrix trans = Matrix.GetTranslation(53, 53, 0);//change offset to center of canvas
            Matrix unit_circle_zero = Matrix.GetTranslation(0, 50, 0);
            //Points
            Point centrum = new Point(0, 0, 0);
            Point zero = unit_circle_zero * centrum;

            point_list.Add(centrum);
            point_list.Add(zero);

            Point t = zero;
            for (int i = 0; i < 12; i++)
            {
                t = rot_pi_6 * t;
                point_list.Add(t);
            }

            foreach (Point point in point_list)
            {
                Point temp = trans * point;//adjuct each point offset to centre of canvas
                canvas.SetPixel(temp, Color.GetRed());
            }
            canvas.Print();
        }
    }
}
