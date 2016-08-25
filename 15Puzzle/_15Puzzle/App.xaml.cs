using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using _15Puzzle.Models;
using _15Puzzle.Views;

namespace _15Puzzle
{
    public partial class App : Application
    {
        public PuzzleModel MainPuzzleModel;

        public int MaxPuzzleSize
        {
            get
            {
                return 5; // Magic
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
