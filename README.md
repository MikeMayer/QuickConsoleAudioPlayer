# QuickConsoleAudioPlayer

I just needed a way to play sounds on specific hardware devices.

## Usage

### No arguments

```
QuickConsoleAudioPlayer
``

This will print out an enumerated list of all sound devices found and available to DirectSound. You will want to take note of the UUID for the device you are interested in.

### Just play the sound on the default device

```
QuickConsoleAudioPlayer {full path to an audio file}
```

This will just play on your device audio device. No need to think too much about it, right?


### Play specified sound on the specified device

```
QuickConsoleAudioPlayer {full path to an audio file} {UUID for desired device}
```

Plays the specified sound on the specified device.

Remember when I said you'd want to take note of the UUID for the device you wanted to play sound from? You use it here to tell QuickConsoleAudioPlayer what device to play sound from.
