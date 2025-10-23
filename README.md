# Broadcasts-plugin
Simple scp:sl plugin for Exiled. Plugin allows to display custom broadcast to player on join to the server or die.

## Configuration
> on join message
> on died message
> broadcast duration

```cs
public string on_join_message { get; set; } = "Welcome to the server {player}!";
public string on_died_message { get; set; } = "You have died. Better luck next time!";
public ushort Broadcast_Duration { get; set; } = 3;
public bool IsEnabled { get; set; } = true;
public bool Debug { get; set; } = false;
```
