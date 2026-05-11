using System;

namespace Wellz.Core.Utils {
    public class Grid<T> {
        private int width;
        private int height;
        private float cellSize;

        public T[,] gridArray;

        public Grid(int width, int height, float cellSize, Func<Grid<T>, int, int, T> createGridObject) {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            gridArray = new T[width, height];

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    gridArray[x, y] = createGridObject(this, x, y);
                }
            }
        }

        public T GetGridObject(int x, int y) {
            if (x >= 0 && x < width && y >= 0 && y < height) {
                return gridArray[x, y];
            } else {
                throw new IndexOutOfRangeException("Grid coordinates out of bounds");
            }
        }

        public int GetLength(int v) {
            if (v == 0) return width;
            if (v == 1) return height;
            throw new ArgumentException("Invalid dimension");
        }

        public float GetCellSize() {
            return cellSize;
        }
    }
}
