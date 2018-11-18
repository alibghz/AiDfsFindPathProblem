using System.Collections.Generic;

namespace AiDfsFindPathProblem
{
    internal class ProblemSolver
    {
        private readonly CellAddress start;
        private readonly CellAddress end;
        private CellAddress currentCell;
        private List<CellAddress> path = new List<CellAddress>();
        private Stack<CellAddress> stack = new Stack<CellAddress>();
        private const int lastRow = 7;
        private const int lastColumn = 5;
        private bool includeBackwardMove = true;
        private int[,] matrix = new int[lastRow + 1, lastColumn + 1];

        public ProblemSolver(CellAddress start, CellAddress end)
        {
            this.start = start;
            this.end = end;
        }

        internal string Solve()
        {
            matrix[end.Row, end.Column] = 1;

            do
            {
                if (Move())
                {
                    path.Add(currentCell);
                    stack.Push(currentCell);
                    if (matrix[currentCell.Row, currentCell.Column] > 0)
                        return $"{string.Join("", path)} ---{path.Count - 1} steps";

                    matrix[currentCell.Row, currentCell.Column] -= 1;
                }
                else if (currentCell.Equals(stack.Peek()))
                    stack.Pop();
                else
                {
                    currentCell = stack.Pop();
                    if (includeBackwardMove) path.Add(currentCell);
                }
            } while (stack.Count > 0);

            return "No Solution";
        }

        private bool Move()
        {
            if (path.Count == 0)
            {
                currentCell = start;
                return true;
            }

            var up = currentCell.Row - 1;
            if (up >= 0 && matrix[up, currentCell.Column] >= 0)
            {
                currentCell.Row = up;
                return true;
            }

            var right = currentCell.Column + 2;
            if (right <= lastColumn && matrix[currentCell.Row, right] >= 0)
            {
                currentCell.Column = right;
                return true;
            }

            var down = currentCell.Row + 1;
            if (down <= lastRow && matrix[down, currentCell.Column] >= 0)
            {
                currentCell.Row = down;
                return true;
            }

            var left = currentCell.Column - 2;
            if (left >= 0 && matrix[currentCell.Row, left] >= 0)
            {
                currentCell.Column = left;
                return true;
            }
            return false;
        }
    }
}