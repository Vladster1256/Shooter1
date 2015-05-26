// Projectile.cs
//Using declarations
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shooter
{
    class HomingProjectile
    {
        // Image representing the Projectile
        public Texture2D Texture;

        Vector2 current = Vector2.Zero;
        Vector2 desired = new Vector2(10, 0);

        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;

        // State of the Projectile
        public bool Active;

        // The amount of damage the projectile can inflict to an enemy
        public int Damage;

        // Represents the viewable boundary of the game
        Viewport viewport;

        // Get the width of the projectile ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the projectile ship
        public int Height
        {
            get { return Texture.Height; }
        }

        // Determines how fast the projectile moves
        float projectileMoveSpeed;


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;

            Active = true;

            Damage = 2;

            projectileMoveSpeed = 10f;
        }

        public void Update(GameTime gameTime)
        {
            // Projectiles always move to the right
             Position.X += projectileMoveSpeed;

            
        }

        
        public Vector2 LerpTowardDesired(Vector2 current, Vector2 desired, float timeDelta)
        {
            float lerpPercentage = timeDelta * 1f;
            Vector2 newPos = Vector2.Zero;
            newPos.X = MathHelper.Lerp(current.X, desired.X, lerpPercentage);
            newPos.Y = MathHelper.Lerp(current.Y, desired.Y, lerpPercentage);

            return newPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
