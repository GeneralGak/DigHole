using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigHole
{
	public class Player : Character, IFocusable
	{

		private int health;
		private string name;


		public int Health
		{
			get { return health; }
			set { health = value; }
		}

		public Player(Vector2 position)
		{
			this.position = position;
			ChangeSprite(Asset.PlayerSprite);
			movementSpeed = 500;
		}


		/// <summary>
		/// Handles user input to Player character
		/// </summary>
		public void HandleInput()
		{
			// If the player is not moving
			velocity = Vector2.Zero;

			// When the player moves the character
			if (Keyboard.IsPressed(Keys.W))
			{
				velocity.Y = -1;
			}

			if (Keyboard.IsPressed(Keys.S))
			{
				velocity.Y = 1;
			}

			if (Keyboard.IsPressed(Keys.A))
			{
				velocity.X = -1;
			}

			if (Keyboard.IsPressed(Keys.D))
			{
				velocity.X = 1;
			}

			if (Keyboard.HasBeenPressed(Keys.G))
			{
				GameWorld.ActiveLevel.Next();
				//Doomsday.RemoveTime(100);
			}

			if (velocity != Vector2.Zero)
			{
				velocity.Normalize();
			}

		}

		public override void OnCollision(GameObject otherObject)
		{

		}

		public override void Attack()
		{
			throw new NotImplementedException();
		}

		public override void Die()
		{
			throw new NotImplementedException();
		}

		public override void Reload()
		{
			throw new NotImplementedException();
		}

		public override void OnTakeDamage()
		{
			throw new NotImplementedException();
		}

		public override void Update(GameTime gameTime)
		{
			// Takes from superClass
			base.Update(gameTime);
			Move(gameTime);

			// From this Class
			HandleInput();
		}

	}
}
