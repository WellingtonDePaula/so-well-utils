using System;
using UnityEngine;

namespace Wellz.Utils.Core {

    /// <summary>
    /// Grade 2D genérica de propósito geral.
    /// Suporta iteração, busca, eventos de mudança e conversão de coordenadas.
    /// </summary>
    [Serializable]
    public class Grid<T> {

        // ─── Campos ───────────────────────────────────────────────────────────
        private readonly int width;
        private readonly int height;
        private readonly T[,] cells;
        private readonly float cellSize;
        private readonly Vector3 originPosition;

        // ─── Eventos ──────────────────────────────────────────────────────────

        /// <summary>Disparado sempre que uma célula é alterada. Passa (x, y, novoValor).</summary>
        public event Action<int, int, T> OnValueChanged;

        // ─── Propriedades ─────────────────────────────────────────────────────
        public int Width => width;
        public int Height => height;
        public float CellSize => cellSize;
        public Vector3 OriginPosition => originPosition;
        public int TotalCells => width * height;

        // ─── Construtor ───────────────────────────────────────────────────────

        public Grid(int width, int height, float cellSize = 1f,
                    Vector3 originPosition = default,
                    Func<Grid<T>, int, int, T> initValue = null) {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.originPosition = originPosition;
            cells = new T[width, height];

            if (initValue != null) {
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                        cells[x, y] = initValue(this, x, y);
            }
        }

        // ─── Acesso por coordenada ────────────────────────────────────────────

        public T GetValue(int x, int y) {
            if (!IsValidPosition(x, y))
                return default;
            return cells[x, y];
        }

        public T GetValue(Vector2Int pos) => GetValue(pos.x, pos.y);

        public bool TryGetValue(int x, int y, out T value) {
            if (!IsValidPosition(x, y)) { value = default; return false; }
            value = cells[x, y];
            return true;
        }

        public void SetValue(int x, int y, T value) {
            if (!IsValidPosition(x, y))
                return;
            cells[x, y] = value;
            OnValueChanged?.Invoke(x, y, value);
        }

        public void SetValue(Vector2Int pos, T value) => SetValue(pos.x, pos.y, value);

        // ─── Conversão de coordenadas ─────────────────────────────────────────

        public Vector3 GetWorldPosition(int x, int y) =>
            new Vector3(x, y) * cellSize + originPosition;

        public Vector2Int GetGridPosition(Vector3 worldPosition) {
            int x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
            int y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
            return new Vector2Int(x, y);
        }

        // ─── Validação ────────────────────────────────────────────────────────

        public bool IsValidPosition(int x, int y) =>
            x >= 0 && y >= 0 && x < width && y < height;

        public bool IsValidPosition(Vector2Int pos) => IsValidPosition(pos.x, pos.y);

        // ─── Iteração e busca ─────────────────────────────────────────────────

        public IEnumerable<T> GetAllValues() {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    yield return cells[x, y];
        }

        public IEnumerable<(int x, int y, T value)> GetAllCells() {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    yield return (x, y, cells[x, y]);
        }

        public bool TryFindFirst(Predicate<T> predicate, out int x, out int y) {
            for (int xi = 0; xi < width; xi++) {
                for (int yi = 0; yi < height; yi++) {
                    if (predicate(cells[xi, yi])) {
                        x = xi;
                        y = yi;
                        return true;
                    }
                }
            }
            x = -1;
            y = -1;
            return false;
        }

        public void ForEach(Action<int, int, T> action) {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    action(x, y, cells[x, y]);
        }

        public void Clear(T defaultValue = default) {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    SetValue(x, y, defaultValue);
        }
    }
}
