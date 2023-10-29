//Console.WriteLine("Hello, World!");
//var temp = ClipBoardManger.GetText();
//ClipBoardManger.SetText("This is test");

using ClipSync.Console;

Console.WriteLine("This is clip Sync Starting up");
Console.WriteLine("------------------------------------");

CallClipboard callClipboard = new CallClipboard();

callClipboard.CallClipboardMonitor();


