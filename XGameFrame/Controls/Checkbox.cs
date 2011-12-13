using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace XGameFrame.Controls
{
    class Checkbox:Control
    {
        #region fields region

        bool isChecked;
        bool isHover;
        Texture2D nonChecked;
        Texture2D hover;
        Texture2D check;
        Rectangle sourceRect;
        Rectangle destRect;

        

        #endregion

        #region Property Region
        
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }

        }

        public bool IsHover
        {
            get { return isHover; }
            set { isHover = value; }

        }

        /// <summary>
        /// the picture if the checkbox is nonchecked
        /// </summary>
        public Texture2D NonChecked
        {
            get { return nonChecked; }
            set { nonChecked = value; }
        }

        /// <summary>
        /// The Hover Picture
        /// </summary>
        public Texture2D Hover
        {
            get { return hover; }
            set { hover = value; }
        }
        /// <summary>
        /// The Checked Picture
        /// </summary>
        public Texture2D Checked
        {
            get { return check; }
            set { check = value; }
        }

        public Rectangle SourceRectangle
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return destRect; }
            set { destRect = value; }
        }
        #endregion

        #region Constructor

        public Checkbox(Texture2D nonChecked,Texture2D check ,Rectangle destination)
        {
            NonChecked = nonChecked;
            Checked = check;
            DestinationRectangle = destination;
            SourceRectangle = new Rectangle(0, 0, Checked.Width, Checked.Height);
            Color = Color.White;
        }

        public Checkbox(Texture2D nonChecked, Texture2D check,Texture2D hover , Rectangle destination)
        {
            NonChecked = nonChecked;
            IsChecked = isChecked;
            Hover = hover;
            DestinationRectangle = destination;
            SourceRectangle = new Rectangle(0, 0, Checked.Width, Checked.Height);
            Color = Color.White;
        }

        #endregion

        #region Abstract Method Region

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsChecked == false)
            {
                spriteBatch.Draw(NonChecked, destRect, sourceRect, Color);
            }
            else
            {
                if (IsHover == true)
                {
                    spriteBatch.Draw(Hover, destRect, sourceRect, Color);
                }
                else
                {
                    spriteBatch.Draw(NonChecked, destRect,sourceRect, Color);
                }
            }

        }

        public override void HandleInput(PlayerIndex playerIndex)
        {

        }

        #endregion

        #region Checkbox Methods

        public void SetPosition(Vector2 newPosition)
        {
            destRect = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                sourceRect.Width,
                sourceRect.Height);
        }

        #endregion



    }
}
