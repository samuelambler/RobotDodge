using SplashKitSDK;

public class RobotDodge
{
	private Player _Player;
	private Window _GameWindow;
	private  List<Robot> _Robots;
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
		_Robots = new List<Robot>();
	}

	public void HandleInput()
	{
		_Player.HandleInput();
		_Player.StayOnWindow(_GameWindow);
	}

	public void Update()
	{
		this.CheckCollisions();

		foreach (Robot i in _Robots)
		{
			i.Update();
		}

		if (SplashKit.Rnd() < 0.1)
		{
			_Robots.Add(RandomRobot());
		}
	}

	private void CheckCollisions()
	{
		List<Robot> _removeRobots = new List<Robot>();

		foreach (Robot i in _Robots)
		{
			if (_Player.CollidedWidth(i) || i.isOffscreen(_GameWindow))
			{
				_removeRobots.Add(i);
			}
		}
		foreach (Robot j in _removeRobots)
		{
			_Robots.Remove(j);
		}
	}
	
	private void UpdateRobots()
	{
		// not sure why this was included in UML diagram
		// assume this will be used in next task - leaving in
	}

	public void Draw()
	{
		_GameWindow.Clear(Color.White);

		_Player.Draw();

		foreach (Robot i in _Robots)
		{
			i.Draw();
		}

		_GameWindow.Refresh(60);
	}

	public Robot RandomRobot()
	{
		Robot _Robot = new Robot(_GameWindow, _Player);
		return _Robot;
	}
}