using SplashKitSDK;

public class RobotDodge
{
	private Player _Player;
	private Window _GameWindow;
	private Robot _TestRobot;
	public bool Quit
	{
		get
		{
			return _Player.Quit;
		}
	}

	public RobotDodge(Window gameWindow)
	{
		_GameWindow = gameWindow;
		_Player = new Player("player", "Player.png", gameWindow);
		_TestRobot = RandomRobot();

	}

	public void HandleInput()
	{
		_Player.HandleInput();
		_Player.StayOnWindow(_GameWindow);
	}

	public void Update()
	{
		if (_Player.CollidedWidth(_TestRobot))
		{
			_TestRobot = RandomRobot();
		}
	}

	public void Draw()
	{
		_GameWindow.Clear(Color.White);

		_Player.Draw();
		_TestRobot.Draw();

		_GameWindow.Refresh(60);

	}

	public Robot RandomRobot()
	{
		Robot _Robot = new Robot(_GameWindow);
		return _Robot;
	}
}