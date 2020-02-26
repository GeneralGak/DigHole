using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigHole
{
	public class Level : Environment
	{

		private List<Room> rooms = new List<Room>();
		private Level previousLevel;
		private int levelNumber = 1;
		private int numberOfEnemies;


		public List<Room> Rooms
		{
			get { return rooms; }
			set { rooms = value; }
		}

		public int NumberOfEnemies
		{
			get { return numberOfEnemies; }
			set { numberOfEnemies = value; }
		}


		/// <summary>
		/// Default Constructor
		/// </summary>
		public Level()
		{

		}

		/// <summary>
		/// Constructor that inmplements enemies
		/// </summary>
		/// <param name="numberOfEnemies"></param>
		public Level(int numberOfEnemies)
		{
			this.NumberOfEnemies = numberOfEnemies;
		}

		/// <summary>
		/// Changes to another level.
		/// </summary>
		public void Next()
		{
			// TODO: Gonna look at the Remove/Add player funktion. May not remove the player in the previous level.
			levelNumber += 1;
			//EnemySpawn.EnemiesSpawn = 0;

			previousLevel = GameWorld.ActiveLevel;

			//GameWorld.RemoveGameObject(GameWorld.player);

			// TODO: Use the Random field to make it different what level the player will encounter on each level Number.
			if (levelNumber == 2)
			{
				GameWorld.ActiveLevel = GameWorld.CaveLevel;
			}


			//GameWorld.AddGameObject(GameWorld.player, GameWorld.ActiveLevel);
			GameWorld.ActiveLevel.Remove(GameWorld.player);

			GameWorld.ActiveLevel.Add(GameWorld.player);

		}

		/// <summary>
		/// Add a room the the level.
		/// </summary>
		/// <param name="room"></param>
		public void AddRoom(Room room)
		{
			if (room != null)
			{
				rooms.Add(room);
			}
		}

		/// <summary>
		/// Changes the ground to fit the level.
		/// </summary>
		public void LevelSprite(SpriteBatch spriteBatch)
		{

			if (GameWorld.ActiveLevel == GameWorld.SurfaceLevel)
			{
				//spriteBatch.Draw(Asset.GrassTexture, new Vector2(), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0f);
			}

			if (GameWorld.ActiveLevel == GameWorld.CaveLevel)
			{
				//spriteBatch.Draw(Asset.GroundTexture, new Vector2(), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0f);
			}

		}

	}
}
