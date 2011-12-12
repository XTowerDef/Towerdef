using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

// use the Framework from moebis
using XGameFrame;
// a class that handles Controlelements
// a little like the wpf controllers
using XGameFrame.Controls;


namespace XTowerDef.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        #region Field region
        // a picture for the Background of the startscreen
        PictureBox backgroundImage;
        // a picture for the arrow 
        // with the arrow you can see where you are in the navigation
        PictureBox arrowImage;
        // a link to start the Game
        LinkLabel startGame;
        // a example Link
        LinkLabel loadGame;
        // to exit the Game
        LinkLabel exitGame;
        // the max. width of the LinkLabels
        float maxItemWidth = 0f;

        #endregion

        #region Property Region

        #endregion

        #region Constructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // have to call first so that the ControlManager exists
            base.LoadContent();

            ContentManager Content = Game.Content;
            // the Picture for the Background
            backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            // add the PictureBox to the ControlManager how will add the control to the 
            ControlManager.Add(backgroundImage);

            Texture2D arrowTexture = Content.Load<Texture2D>(@"GUI\leftarrowUp");

            arrowImage = new PictureBox(
                arrowTexture,
                new Rectangle(
                    0,
                    0,
                    arrowTexture.Width,
                    arrowTexture.Height));
            ControlManager.Add(arrowImage);

            startGame = new LinkLabel();
            startGame.Text = "Start xy \na new cool line";
            // size it to the Size of the text with that SpriteFont
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            // that will handle the Selected event of all menu items.
            startGame.Selected += new EventHandler(menuItem_Selected);

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "Load xy";
            loadGame.Size = loadGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.Selected += menuItem_Selected;

            ControlManager.Add(loadGame);

            Label advice = new Label();
            advice.Text = "A big advice for the Game";
            advice.Size = advice.SpriteFont.MeasureString(advice.Text);
            advice.Position = new Vector2(25f, 25f);

            ControlManager.Add(advice);

            exitGame = new LinkLabel();
            exitGame.Text = "xy exit";
            exitGame.Size = exitGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.Selected += menuItem_Selected;

            ControlManager.Add(exitGame);

            ControlManager.NextControl();

            ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);
            Vector2 position = new Vector2(350, 500);

            // In the loop I check to see if the control is a
            // LinkLabel. If it is I compare the X property of its size with maxItemWidth field. If it is greater I set
            // maxItemWidth to that value. I then set the Position property of the control to the Vector2 I created. I
            // then increase the Y property of the Vector2 by the Y property of the Size property of the control plus
            // five pixels.
            foreach (Control c in ControlManager)
            {
                if (c is LinkLabel)
                {
                    if (c.Size.X > maxItemWidth)
                        maxItemWidth = c.Size.X;

                    c.Position = position;
                    position.Y += c.Size.Y + 5f;

                }
            }
            // I call the FocusChanged event handler passing in the startGame control and
            // null. What this does is call the code that positions the arrow to the right of the sender. In this case, the
            // arrow will be to the right of the startGame item.
            ControlManager_FocusChanged(startGame, null);

        }
        // accept the sender as a control and place the arrow after the control position
        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f,
                control.Position.Y);
            arrowImage.SetPosition(position);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {
            if (sender == startGame)
            {
                StateManager.PushState(GameRef.GamePlayScreen);
            }
            if (sender == loadGame)
            {
                StateManager.PushState(GameRef.GamePlayScreen);
            }
            if (sender == exitGame)
            {
                GameRef.Exit();
            }
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            ControlManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Game State Method Region

        #endregion

    }
}