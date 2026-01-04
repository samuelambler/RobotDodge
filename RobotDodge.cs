using System.Security.Cryptography.X509Certificates;
using SplashKitSDK;

public class RobotDodge
{
	private Player _Player;
	private Window _GameWindow;
	private List<Robot> _Robots;
	private List<Bullet> _Bullets;
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
		_Bullets = new List<Bullet>();
	}

	public void HandleInput()
	{
		_Player.HandleInput();
		_Player.StayOnWindow(_GameWindow);

		if (SplashKit.MouseClicked(MouseButton.LeftButton))
		{
			_Bullets.Add(new Bullet(_Player.X + _Player.Width / 2, _Player.Y + _Player.Height / 2, SplashKit.MousePosition()));
		}
	}

	public void Update()
	{
		this.CheckCollisions();

		foreach (Robot i in _Robots)
		{
			i.Update();
		}

		foreach (Bullet b in _Bullets)
		{
			b.Update();
		}

		if (SplashKit.Rnd() < 0.03)
		{
			_Robots.Add(RandomRobot());
		}
	}

	private void CheckCollisions()
	{
		List<Robot> _removeRobots = new List<Robot>();
		List<Bullet> _removeBullets = new List<Bullet>();

		foreach (Robot i in _Robots)
		{
			if (_Player.CollidedWidth(i) || i.IsOffScreen(_GameWindow))
			{
				_removeRobots.Add(i);
			}
		}

		foreach (Bullet b in _Bullets)
		{
			if (b.IsOffScreen(_GameWindow))
			{
				_removeBullets.Add(b);
			}
			else
			{
				foreach (Robot r in _Robots)
				{
					if (!_removeRobots.Contains(r) && SplashKit.CirclesIntersect(b.CollisionCircle, r.CollisionCircle))
					{
						_removeRobots.Add(r);
						_removeBullets.Add(b);
						break;
					}
				}
			}
		}

		foreach (Robot j in _removeRobots)
		{
			_Robots.Remove(j);
		}
		foreach (Bullet k in _removeBullets)
		{
			_Bullets.Remove(k);
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

		foreach (Bullet b in _Bullets)
		{
			b.Draw();
		}

		_GameWindow.Refresh(60);
	}

	public Robot RandomRobot()
	{
		float rand = SplashKit.Rnd();

		if (rand < 0.33)
		{
			Robot _Robot = new Boxy(_GameWindow, _Player);
			return _Robot;
		}
		else if (rand > 0.66)
		{
			Robot _Robot = new Roundy(_GameWindow, _Player);
			return _Robot;
		}
		else
		{
			Robot _Robot = new Spiky(_GameWindow, _Player);
			return _Robot;
		}
	}
}