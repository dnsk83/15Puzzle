using System;
using Xamarin.Forms;
using _15Puzzle.Models;

namespace _15Puzzle.Views
{
    public partial class Game : ContentPage
    {
        private PuzzleModel _puzzleModel;

        public Game()
        {
            InitializeComponent();

            LoadPuzzleModel();
            InitPuzzle();
            RefreshPuzzleView();
        }

        private void InitPuzzle()
        {
            for (int i = 0; i < _puzzleModel.SideLength; i++)
            {
                grdPuzzle.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)});
                grdPuzzle.RowDefinitions.Add(new RowDefinition {Height = new GridLength(1, GridUnitType.Star)});
            }

            for (int i = 0; i < _puzzleModel.SideLength; i++)
            {
                for (int j = 0; j < _puzzleModel.SideLength; j++)
                {
                    var btn = new Button
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof (Button)),
                    };
                    var row = i;
                    var col = j;
                    btn.Clicked += (o, args) =>
                    {
                        _puzzleModel.Touch(row, col);
                        RefreshPuzzleView();
                    };
                    grdPuzzle.Children.Add(btn, i, j);
                }
            }
        }

        private void LoadPuzzleModel()
        {
            var app = Application.Current as App;
            if (app != null)
            {
                if (app.MainPuzzleModel == null)
                {
                    app.MainPuzzleModel = new PuzzleModel();
                }
                _puzzleModel = app.MainPuzzleModel;
            }
        }

        public void RestartGame()
        {
            _puzzleModel.FillCellsWithRandoms();
            RefreshPuzzleView();
        }

        private void RefreshPuzzleView()
        {
            for (int i = 0; i < _puzzleModel.SideLength; i++)
            {
                for (int j = 0; j < _puzzleModel.SideLength; j++)
                {
                    var btn = (Button)grdPuzzle.Children[i * _puzzleModel.SideLength + j];
                    btn.Text = _puzzleModel.Cells[i, j].ToString();
                    btn.TextColor = _puzzleModel.Cells[i, j] == 0 ? Color.Transparent : Color.White;
                    btn.BackgroundColor = _puzzleModel.Cells[i, j] == 0 ? Color.Transparent : Color.Teal;
                }
            }
        }

    }
}
