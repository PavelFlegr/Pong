using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Game.Models
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Size { get; set; }
        //same direction vector of size 1
        public Vector Unit => new Vector(X / Size, Y / Size);

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
            Size = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public void Deconstruct(out double x, out double y)
        {
            x = X;
            y = Y;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }
}
