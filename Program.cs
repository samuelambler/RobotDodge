using System;
using SplashKitSDK;

namespace RobotDodge
{
	public class Program
	{
		public static void Main()
		{
			Window gameWindow = new Window("This is the Game Window", 800, 800);
			Player gamePlayer = new Player("player", "Player.png", gameWindow);

			while (!SplashKit.QuitRequested())
			{
				SplashKit.ProcessEvents();
				gameWindow.Clear(Color.White);

				gamePlayer.Draw();

				gameWindow.Refresh(60);
			}
		}
	}
}
