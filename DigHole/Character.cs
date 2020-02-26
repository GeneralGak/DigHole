using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigHole
{
	public abstract class Character : GameObject
	{

		protected Vector2 positionPreMove;
		protected Vector2 velocity;
		protected float invinsibilityTimer;
		protected float deltaTime;
		protected float movementSpeed;
		protected bool takeDamage;

		/// <summary>
		/// Default
		/// </summary>
		protected int health = 1;

		/// <summary>
		/// Default
		/// </summary>
		protected float invinsibilityTimeAfterDamage = .75f;

		/// <summary>
		/// Default
		/// </summary>
		protected bool isAlive = true;


		public int Health
		{
			get { return health; }
			set
			{
				health = value;
				if (health < 0)
				{
					health = 0;
				}
			}
		}

		public bool TakeDamage
		{
			get { return takeDamage; }
			set { takeDamage = value; }
		}

		public bool IsAlive
		{
			get { return isAlive; }
			set { isAlive = value; }
		}

		//public Weapon SelectedWeapon
		//{
		//	get { return selectedWeapon; }
		//	set { selectedWeapon = value; }
		//}

		/// <summary>
		/// Character dies
		/// </summary>
		public abstract void Die();

		/// <summary>
		/// Character attacks
		/// </summary>
		public abstract void Attack();

		/// <summary>
		/// Character reloads selected weapon
		/// </summary>
		public abstract void Reload();

		/// <summary>
		/// Something happens when character takes damage.
		/// </summary>
		public abstract void OnTakeDamage();


		public virtual void Move(GameTime gameTime)
		{
			// deltaTime based on GameTime
			deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			// Moves the player based on velocity
			position += ((velocity * movementSpeed) * deltaTime);
		}

		/// <summary>
		/// Update the characters health.
		/// </summary>
		/// <param name="damage"></param>
		/// <returns></returns>
		public virtual int UpdateHealth(int damage)
		{
			if (invinsibilityTimer > invinsibilityTimeAfterDamage)
			{
				if (damage > 0)
				{
					Health -= damage;
				}
				else
				{
					Health += Math.Abs(damage);
				}

				// Resets a timer, so that character can't take damage right after.
				invinsibilityTimer = 0;

				// if health reaches 0.
				if (Health <= 0)
				{
					Die();
				}

				OnTakeDamage();
			}
			return Health;
		}

		public override void OnCollision(GameObject otherObject)
		{

		}

		public override void Update(GameTime gameTime)
		{
			if (invinsibilityTimer < invinsibilityTimeAfterDamage)
			{
				invinsibilityTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
			}
		}

	}
}
