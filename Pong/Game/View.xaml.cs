using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pong.Game.Models;

namespace Pong.Game
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Page
    {
        public static Ball currentBall;
        List<GameObject> gameObjects = new List<GameObject>();
        GameObject player1;
        GameObject player2;
        Ball ball;
        Bounds bounds;
        public View(GameObject player1, GameObject player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            InitializeComponent();
            game.Loaded += Game_Loaded;
        }

        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            bounds = new Bounds(new Models.Vector(0, 0), new Models.Rectangle(game.ActualWidth, game.ActualHeight));
            player1.Position = new Models.Vector(bounds.Left + 20, 0);
            player2.Position = new Models.Vector(bounds.Right - 20, 0);
            ball = new Ball();
            currentBall = ball;
            game.Children.Add(ball.sprite);
            game.Children.Add(player1.sprite);
            game.Children.Add(player2.sprite);

            gameObjects.Add(player1);
            gameObjects.Add(player2);
            gameObjects.Add(ball);
            var r = new Random();
            ball.Velocity = new Models.Vector(r.Next(2) == 1 ? -5 : 5, r.Next(2) == 1 ? 2 : -2);
            CompositionTarget.Rendering += MainLoop;
        }

        void MainLoop(object o, EventArgs e)
        {
            Updates();
            Physics();
            Collisions();
            Draw();
        }

        void Updates()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update();
            }
        }

        void EndGame(GameObject winner, GameObject loser)
        {
            Canvas.SetLeft(feelsgoodman, winner.Position.X + game.ActualWidth / 2 - winner.Size.Width / 2 - feelsgoodman.Width / 2);
            Canvas.SetBottom(feelsgoodman, winner.Position.Y + game.ActualHeight / 2 - winner.Size.Height / 2);
            Canvas.SetLeft(feelsbadman, loser.Position.X + game.ActualWidth / 2 - loser.Size.Width / 2 - feelsbadman.Width / 2);
            Canvas.SetBottom(feelsbadman, loser.Position.Y + game.ActualHeight / 2 - loser.Size.Height / 2);
            feelsbadman.Visibility = Visibility.Visible;
            feelsgoodman.Visibility = Visibility.Visible;
            gameOver.Visibility = Visibility.Visible;
            CompositionTarget.Rendering -= MainLoop;
        }

        void Collisions()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.Bounds.Top > bounds.Top)
                {
                    gameObject.Position = new Models.Vector(gameObject.Position.X, bounds.Top - gameObject.Size.Height / 2);
                    gameObject.Collision(new Wall());
                }
                else if (gameObject.Bounds.Bottom < bounds.Bottom)
                {
                    gameObject.Position = new Models.Vector(gameObject.Position.X, bounds.Bottom + gameObject.Size.Height / 2);
                    gameObject.Collision(new Wall());
                }
            }

            if (ball.Bounds.Left <= player1.Bounds.Right && ball.Bounds.Bottom < player1.Bounds.Top && ball.Bounds.Top > player1.Bounds.Bottom)
            {
                ball.Position = new Models.Vector(player1.Bounds.Right + ball.Size.Width / 2, ball.Position.Y);
                ball.Collision(player1);
            }
            else if (ball.Bounds.Right >= player2.Bounds.Left && ball.Bounds.Bottom < player2.Bounds.Top && ball.Bounds.Top > player2.Bounds.Bottom)
            {
                ball.Collision(player2);
                ball.Position = new Models.Vector(player2.Bounds.Left - ball.Size.Width / 2, ball.Position.Y);
            }

            if (ball.Bounds.Left < bounds.Left)
            {
                EndGame(player2, player1);
            }
            else if (ball.Bounds.Right > bounds.Right)
            {
                EndGame(player1, player2);
            }
        }

        void Physics()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Position += gameObject.Velocity;
            }
        }

        void Draw()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Canvas.SetLeft(gameObject.sprite, gameObject.Position.X + game.ActualWidth / 2 - gameObject.Size.Width / 2);
                Canvas.SetBottom(gameObject.sprite, gameObject.Position.Y + game.ActualHeight / 2 - gameObject.Size.Height / 2);
                gameObject.sprite.Width = gameObject.Size.Width;
                gameObject.sprite.Height = gameObject.Size.Height;
            }
        }

        void MainMenu(object o, EventArgs e)
        {
            NavigationService.Content = new MainMenu();
        }
    }
}
