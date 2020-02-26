using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DigHole
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class GameWorld : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// To get random numbers
		public static Random Random = new Random();

		// To add and remove objects doing runtime.
		public static List<GameObject> NewGameObjects = new List<GameObject>();
		public static List<GameObject> RemoveGameObjects = new List<GameObject>();

		public static void AddGameObject(GameObject gameObject, Level level)
		{
			gameObject.Level = level;
			NewGameObjects.Add(gameObject);
		}

		public static void RemoveGameObject(GameObject gameObject)
		{
			RemoveGameObjects.Add(gameObject);
		}


		// Used to pause the game.
		private bool isPaused;

		// The Active Level. Only objects from this level gets updated and drawn.
		public static Level ActiveLevel;

		// The Active Room. Only objects from this room gets updated and drawn.
		public static Room ActiveRoom;

		// Different kinds of levels.
		public static Level SurfaceLevel;
		public static Level CaveLevel;
		public static Level HorrorLevel;
		public static Level HellLevel;
		public static Level DeepCaveLevel;

		// Different kinds of Rooms
		public static Room House1FloorRoom;
		public static Room House2FloorRoom;
		public static Room RuinRoom;
		public static Room Tempel1FloorRoom;
		public static Room Tempel2FloorRoom;
		public static Room TempelMainRoom;

		// The Camera (Testing)
		public static Camera2D Camera;

		// The Player Character
		public static Player player;

		// The Game Screen dimensions
		public static int displayWidth = 1920;
		public static int displayHeight = 1080;


		public GameWorld()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			//Screen setup
			graphics.PreferredBackBufferWidth = displayWidth;
			graphics.PreferredBackBufferHeight = displayHeight;
			graphics.ApplyChanges();

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// Loads all the game assets like sprites
			Asset.LoadContent(Content);

			// TODO: use this.Content to load your game content here

			// Make Levels
			SurfaceLevel = new Level(5);
			CaveLevel = new Level(10);

			// TODO: use this.Content to load your game content here
			player = new Player(new Vector2(100, 100));

			// Set Active Level
			ActiveLevel = SurfaceLevel;

			// Set Player
			ActiveLevel.Add(player);

			// Camera setup
			Camera = new Camera2D(this, player);

		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			// To be able to stop or start the game.
			GamePauseInput();

			if (isPaused == true)
			{

			}

			if (isPaused == false)
			{
				// Used to count down to when the game ends
				//Doomsday.DeathClockTimer(gameTime);

				foreach (GameObject gameObject in ActiveLevel.GameObjects)
				{
					gameObject.Update(gameTime);
					foreach (GameObject otherobject in ActiveLevel.GameObjects)
					{
						gameObject.CheckCollision(otherobject);
					}
				}

				// Add new objects to rooms
				foreach (GameObject gameObject in NewGameObjects)
				{
					gameObject.Level.Add(gameObject);
				}
				NewGameObjects.Clear();

				// Remove gameobjects from rooms
				foreach (GameObject gameObject in RemoveGameObjects)
				{
					if (gameObject.Level != null)
					{
						gameObject.Level.Remove(gameObject);
					}
					else
					{
						ActiveLevel.Remove(gameObject);
					}
				}
				RemoveGameObjects.Clear();

				Camera.Update(gameTime);

				// Spawns the Enemies
				//EnemySpawn.Spawn(ActiveLevel, player);
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Camera.Transform);

			// Draws the Level Background.
			ActiveLevel.LevelSprite(spriteBatch);

			// Draws the Game Objects.
			foreach (GameObject gameObject in ActiveLevel.GameObjects)
			{
				gameObject.Draw(spriteBatch);
			}


			spriteBatch.End();

			base.Draw(gameTime);
		}

		public bool IsGamePaused()
		{
			return isPaused;
		}

		public void GamePauseInput()
		{
			if (Keyboard.HasBeenPressed(Keys.Q))
			{
				TogglePause();
			}
		}

		public void PauseGame()
		{
			isPaused = true;
		}

		public void UnpauseGame()
		{
			isPaused = false;
		}

		public void TogglePause()
		{
			if (IsGamePaused())
			{
				UnpauseGame();
			}
			else
			{
				PauseGame();
			}
		}
	}
}
