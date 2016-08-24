using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using _15Puzzle.Models;

namespace _15Puzzle.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException!=null)
                {
                    var innerMessage = ex.InnerException.Message; 
                }
                throw;
            }

            menu.CellSettings.Tapped += CellSettings_Tapped;
            menu.CellRestart.Tapped += CellRestart_Tapped;
            menu.CellPlay.Tapped += CellPlay_Tapped;
        }

        private void CellPlay_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Game());
            IsPresented = false;
        }

        private async void CellRestart_Tapped(object sender, EventArgs e)
        {
            var page = Detail as NavigationPage;
            var game = page.CurrentPage as Game;

            bool restart = await DisplayAlert("Start new game", "Do you really want to restart the game?", "Yes", "No");

            if (restart)
            {
                if (game != null)
                {
                    game.RestartGame();
                }
            }

            Detail = new NavigationPage(new Game());
            IsPresented = false;
        }

        private void CellSettings_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Settings());
            IsPresented = false;
        }

    }
}
