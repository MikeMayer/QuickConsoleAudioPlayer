using NAudio.Wave;

var firstParameter = args.FirstOrDefault() ?? "--list-devices";

if (firstParameter == "--list-devices")
{
    foreach (var dev in DirectSoundOut.Devices)
    {
        Console.WriteLine($"{dev.Guid} - {dev.Description}");
    }
    return;
}

Guid deviceGuid;
var secondParameter = args.ElementAtOrDefault(1) ?? Guid.Empty.ToString();

if (!Guid.TryParse(secondParameter, out deviceGuid))
{
    Console.WriteLine($"Invalid device uuid: {secondParameter}");
    return;
}

using (var audioFile = new AudioFileReader(firstParameter))
{
    using var outputDevice = new DirectSoundOut(deviceGuid);
    outputDevice.Init(audioFile);
    outputDevice.Play();

    if (deviceGuid == Guid.Empty)
    {
        Console.WriteLine($"Playing {Path.GetFileName(firstParameter)}");
    }
    else
    {
        Console.WriteLine($"Playing {Path.GetFileName(firstParameter)} on {deviceGuid}");
    }

    while (outputDevice.PlaybackState == PlaybackState.Playing)
    {
        Thread.Sleep(1000);
    }
}
