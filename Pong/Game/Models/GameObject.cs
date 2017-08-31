using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Game.Models
{
    public class GameObject
    {
        public System.Windows.FrameworkElement sprite = new System.Windows.Shapes.Rectangle { Fill = System.Windows.Media.Brushes.White };
        public Bounds Bounds;
        public Vector Position
        {
            get => position;
            set
            {
                position = value;
                Bounds = new Bounds(position, size);
            }
        }
        Vector position;
        public Vector Velocity;
        public Rectangle Size
        {
            get => size;
            set
            {
                size = value;
                Bounds = new Bounds(position, size);
            }
        }
        Rectangle size;

        public virtual void Update() { }
        public virtual void Collision(Collision type) { }
    }
}
