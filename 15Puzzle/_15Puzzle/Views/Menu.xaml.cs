using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using _15Puzzle;

namespace _15Puzzle.Views
{
    public partial class Menu : ContentPage
    {
        public TableView TableMenu
        {
            get { return tblMenu; }
        }

        public ViewCell CellSettings
        {
            get { return cellSettings; }
        }

        public ViewCell CellRestart
        {
            get { return cellRestart; }
        }

        public ViewCell CellPlay
        {
            get { return cellPlay; }
        }

        public Menu()
        {
            InitializeComponent();
        }
    }
}
