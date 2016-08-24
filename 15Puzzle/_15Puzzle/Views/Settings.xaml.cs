using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using _15Puzzle.Models;

namespace _15Puzzle.Views
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Button33_OnClicked(object sender, EventArgs e)
        {
            StartNewGameWithSideLength(3);
        }

        private void Button44_OnClicked(object sender, EventArgs e)
        {
            StartNewGameWithSideLength(4);
        }

        private void Button55_OnClicked(object sender, EventArgs e)
        {
            StartNewGameWithSideLength(5);
        }

        async void StartNewGameWithSideLength(int length)
        {
            var restart = await DisplayAlert("Apply changes now?", "Do you really want to restart the game with new settings?", "Yes", "No");

            if (restart)
            {
                var app = App.Current as App;
                app.MainPuzzleModel = new PuzzleModel(length);

                var mp = app.MainPage as MainPage;

                var game = new Game();
                game.RestartGame();

                mp.Detail = new NavigationPage(game);

            }

        }
    }
}
