using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using _15Puzzle.Models;

namespace _15Puzzle
{
    public partial class MainPage : ContentPage
    {
        private PuzzleModel TestModel;

        public MainPage()
        {
            InitializeComponent();

            TestModel = new PuzzleModel();

            for (int i = 0; i < TestModel.SideLength; i++)
            {
                for (int j = 0; j < TestModel.SideLength; j++)
                {
                    var btn = new Button
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                        //FontAttributes = FontAttributes.Bold
                    };
                    var row = i;
                    var col = j;
                    btn.Clicked += (o, args) =>
                    {
                        TestModel.Touch(row, col);
                        Refresh();
                    };
                    grdPuzzle.Children.Add(btn, i, j);
                }
            }
            Refresh();
        }

        private async void btnRestart_OnClicked(object sender, EventArgs e)
        {
            bool restart = await DisplayAlert("Start new game", "Do you really want to restart the game", "Yes", "No");
            if (restart)
            {
                TestModel.Reset();
                Refresh();
            }
        }

        private void Refresh()
        {
            for (int i = 0; i < TestModel.SideLength; i++)
            {
                for (int j = 0; j < TestModel.SideLength; j++)
                {
                    var btn = (Button)grdPuzzle.Children[i * TestModel.SideLength + j];
                    btn.Text = TestModel.Cells[i, j].ToString();
                    btn.TextColor = TestModel.Cells[i, j] == 0 ? Color.Aqua : Color.White;
                    btn.BackgroundColor = TestModel.Cells[i, j] == 0 ? Color.Olive : Color.Teal;
                }
            }
        }

    }
}
