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

            var maxPuzzleSize = ((App) App.Current).MaxPuzzleSize;
            var currentPuzzleSize = ((App)App.Current).MainPuzzleModel.SideLength;

            stprSize.Value = currentPuzzleSize;

            DrawGrid(maxPuzzleSize);
            RerawGridForSize(currentPuzzleSize);
        }

        private void DrawGrid(int size)
        {
            for (int i = 0; i < size; i++)
            {
                grdSize.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)});
                grdSize.RowDefinitions.Add(new RowDefinition {Height = new GridLength(1, GridUnitType.Star)});
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var box = new BoxView {BackgroundColor = Color.Black};
                    grdSize.Children.Add(box, i, j);
                }
            }
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

        private void Stepper_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            RerawGridForSize((int)Math.Floor(e.NewValue));
        }

        private void RerawGridForSize(int size)
        {
            for (int i = 0; i < grdSize.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < grdSize.ColumnDefinitions.Count; j++)
                {
                    var box = (BoxView)grdSize.Children[i * grdSize.ColumnDefinitions.Count + j];

                    if (i < size && j < size)
                    {
                        box.BackgroundColor = Color.Teal;
                    }
                    else
                    {
                        box.BackgroundColor = Color.Black;
                    }
                }
            }
        }

        private void BtnApply_OnClicked(object sender, EventArgs e)
        {
            StartNewGameWithSideLength((int)Math.Floor(stprSize.Value));
        }
    }
}
