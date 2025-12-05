using System;
using SplashKitSDK;

namespace RobotDodgeGame
{
	public class Program
	{
		public static void Main()
		{
			Window gameWindow = new Window("This is the Game Window", 800, 800);
			RobotDodge game = new RobotDodge(gameWindow);

			while (!SplashKit.QuitRequested() && !game.Quit)
			{
				SplashKit.ProcessEvents();
				game.HandleInput();
				game.Update();
				game.Draw();
			}
		}
	}
}
