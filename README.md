# RecursionLab – Recursividad en Windows Forms (.NET 10)

Abrir `RecursionLab.slnx` con Visual Studio 2026 (o `dotnet run --project RecursionLab`).
Requiere .NET 10 SDK y Windows.

## Pestañas
1. **Torres de Hanoi** – resolución recursiva con animación, lista de movimientos y métricas (llamadas = 2^n − 1, profundidad = n).
2. **Laberinto (backtracking)** – el laberinto se genera con DFS recursivo y se resuelve con backtracking recursivo; se anima la exploración y el camino final.
3. **Análisis de profundidad** – benchmark de Hanoi, Fibonacci (ingenuo / memoizado), suma recursiva y N-Reinas:
   tiempo (mediana de N repeticiones), nº de llamadas y profundidad máxima, con gráfico (lineal/log),
   ajuste automático de modelo (exponencial vs polinómico) y prueba del límite de pila.

## Estructura
- `Core/` lógica recursiva y medición (sin dependencias de UI)
- `Controls/` controles propios (HanoiCanvas, MazeCanvas, ChartControl)
- `MainForm.cs` + `MainForm.Designer.cs` interfaz
