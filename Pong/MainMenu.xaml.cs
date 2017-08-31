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

namespace Pong
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void PlayAI(object o, EventArgs e)
        {
            NavigationService.Content = new Game.View(new Game.Models.Player(Game.Models.Controls.UpDown), new Game.Models.Computer());
        }

        public void Play2(object o, EventArgs e)
        {
            NavigationService.Content = new Game.View(new Game.Models.Player(Game.Models.Controls.UpDown), new Game.Models.Player(Game.Models.Controls.SX));
        }

        public void Exit(object o, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
