namespace RecursionLab.Core;

/// <summary>
/// Ejecuta trabajo en un hilo con pila grande. El hilo principal de Windows solo tiene ~1 MB de pila,
/// lo que limita la recursión profunda a decenas de miles de llamadas.
/// </summary>
public static class StackRunner
{
    public static Task<T> RunAsync<T>(Func<T> work, int stackMegabytes = 256)
    {
        var tcs = new TaskCompletionSource<T>();
        var thread = new Thread(() =>
        {
            try { tcs.SetResult(work()); }
            catch (Exception ex) { tcs.SetException(ex); }
        }, stackMegabytes * 1024 * 1024)
        { IsBackground = true };
        thread.Start();
        return tcs.Task;
    }
}
