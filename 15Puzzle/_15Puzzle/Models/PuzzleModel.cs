using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle.Models
{
    public class PuzzleModel
    {
        int _sideLength = 4;
        public int SideLength
        {
            get { return _sideLength; }
        }

        int[,] _cells;
        public int[,] Cells
        {
            get
            {
                return _cells;
            }
        }

        public PuzzleModel()
        {
            InitCells();
            FillCellsWithRandoms();
        }


        public PuzzleModel(int sideLength)// : this()
        {
            _sideLength = sideLength;
            InitCells();
            FillCellsWithRandoms();
        }

        private void InitCells()
        {
            _cells = new int[SideLength, SideLength];
        }

        public void FillCellsWithRandoms()
        {
            List<int> items = new List<int>();

            for (int i = 0; i < SideLength*SideLength; i++)
            {
                items.Add(i);
            }

            Random r = new Random();

            for(int i=0;i< SideLength; i++)
                for (int j = 0; j < SideLength; j++)
                {
                    var index = r.Next(items.Count);
                    _cells[i, j] = items[index];
                    items.RemoveAt(index);
                }
        }

        public bool Touch(int row, int col)
        {
            if(row > 0)
                if (_cells[row - 1, col] == 0)
                {
                    _cells[row - 1, col] = _cells[row, col];
                    _cells[row, col] = 0;

                    return true;
                }

            if (col > 0)
                if (_cells[row, col - 1] == 0)
                {
                    _cells[row, col - 1] = _cells[row, col];
                    _cells[row, col] = 0;

                    return true;
                }

            if (row < SideLength - 1)
                if (_cells[row + 1, col] == 0)
                {
                    _cells[row + 1, col] = _cells[row, col];
                    _cells[row, col] = 0;

                    return true;
                }

            if (col < SideLength - 1)
                if (_cells[row, col + 1] == 0)
                {
                    _cells[row, col + 1] = _cells[row, col];
                    _cells[row, col] = 0;

                    return true;
                }

            return false;
        }
    }
}
