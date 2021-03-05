using System;
using System.Collections.Generic;
using System.Text;


namespace RTC
{

            //Canvas canvas = new Canvas(1000, 1000);
            //Color red = new Color().SetRed();
            ////projectile
            //Point StartPosition = new Point(0, 1, 0);
            //Vector StartDirection = new Vector(1, 1.8d, 0).Normalize();
            //Projectile projectile = new Projectile(StartPosition, StartDirection);
            //Vector Gravity = new Vector(0, -0.01d, 0);
            //Vector Wind = new Vector(-0.1, 0, 0);
            //Environment environment = new Environment(Gravity, Wind);


            //while (true)
            //{
            //    Canon.Tick(projectile, environment);
            //    if (projectile.y_position <= 0 || projectile.x_position <= 0)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(projectile);
            //    canvas.SetPixel(projectile.GetPosition(), red, 1);
            //}
            //canvas.Print();
    public class Projectile
    {
        public double x_position;
        public double y_position;
        public double z_position;
        public double x_velo;
        public double y_velo;
        public double z_velo;
        public Projectile(Point Pos, Vector Velo)
        {
            x_position = Pos.x;
            y_position = Pos.y;
            z_position = Pos.z;
            x_velo = Velo.x;
            y_velo = Velo.y;
            z_velo = Velo.z;
        }
        public Point GetPosition()
        {
            return new Point((int)(x_position * 10), (int)(y_position * 10), 0);
        }
        public override string ToString()
        {
            return $"{(int)(x_position*10)} {(int)(y_position*10)}";
        }
    }
    public class Environment
    {
        public double x_gravity;
        public double y_gravity;
        public double z_gravity;
        public double x_wind;
        public double y_wind;
        public double z_wind;
        public Environment(Vector gravity, Vector wind)
        {
            x_gravity = gravity.x;
            y_gravity = gravity.y;
            z_gravity = gravity.z;
            x_wind = wind.x;
            y_wind = wind.y;
            z_wind = wind.z;
        }
    }
    public class Canon
    {
        public static void Tick(Projectile proj, Environment env)
        {
            proj.x_position += proj.x_velo;
            proj.y_position += proj.y_velo;
            proj.z_position += proj.z_velo;
            proj.x_velo = proj.x_velo + env.x_wind + env.x_gravity;
            proj.y_velo = proj.y_velo + env.y_wind + env.y_gravity;
            proj.z_velo = proj.z_velo + env.z_wind + env.z_gravity;
        }
    }
}



