namespace WebCalc.Services;

public class ExceptionService
{
    public static void CreateException(Exception exception)
    {
        var folder = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = folder + "\\log.txt";

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        try
        {
            using var writer = File.Exists(filePath) ? File.AppendText(filePath) : File.CreateText(filePath);
            writer.WriteLine($"Exception Message: {exception.Message}");
            writer.WriteLine($"Stack Trace: {exception.StackTrace}");
            writer.WriteLine($"Occurred on: {DateTime.Now}");
            writer.WriteLine(new string('-', 50));
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while writing to the log file", ex);
        }

        throw new Exception(exception.Message);
    }
}