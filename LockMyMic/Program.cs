using NAudio.CoreAudioApi;
using NAudio.Mixer;

namespace LockMyMic
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int targetVolume = 30;  // Default target volume
            int pollingInterval = 500;  // Default polling interval

            if (args.Length == 0)
            {
                Console.WriteLine("No arguments provided. Use -h argument for help. Using default target volume (30%) and polling interval (500 ms).");
            }

            if (args.Length == 1 && args[0] == "-h" || args.Length == 1 && args[0] == "h")
            {
                Console.WriteLine("Usage: LockMyMic <targetVolume> <pollingInterval>");
                Console.WriteLine("\nArguments:");
                Console.WriteLine("  targetVolume:   Desired microphone volume level (0-100)");
                Console.WriteLine("  pollingInterval: Time in milliseconds between volume checks");
                return;
            }

            if (args.Length >= 1 && (!int.TryParse(args[0], out targetVolume) || targetVolume < 0 || targetVolume > 100))
            {
                Console.WriteLine("Invalid volume level argument. Please provide a valid integer between 0 and 100.");
                return;
            }

            if (args.Length >= 2 && !int.TryParse(args[1], out pollingInterval))
            {
                Console.WriteLine("Invalid polling interval argument. Please provide a valid integer.");
                return;
            }

            UnsignedMixerControl volumeControl = null;
            int waveInDeviceNumber = 0;
            var mixerLine = new MixerLine(waveInDeviceNumber, 0, MixerFlags.WaveIn);

            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == MixerControlType.Volume)
                {
                    volumeControl = control as UnsignedMixerControl;
                    break;
                }
            }

            while (true)
            {
                Console.Title = $"Microphone level: {Math.Round(volumeControl.Percent)}%";

                if (Math.Round(volumeControl.Percent) != targetVolume)
                {
                    volumeControl.Percent = targetVolume;
                    Console.Title = "Microphone level has been adjusted";
                    Console.WriteLine($"Volume adjusted to {targetVolume}%");
                }

                await Task.Delay(pollingInterval);
            }
        }
    }
}
