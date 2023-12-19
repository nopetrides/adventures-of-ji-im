using HelloMurder.Core;
using Microsoft.Xna.Framework.Input;
using Murder;
using Murder.Core.Input;
using System.Collections.Immutable;

namespace HelloMurder
{
    /// <summary>
    /// <inheritdoc cref="IMurderGame"/>
    /// </summary>
    public class HelloMurderGame : IMurderGame
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Name => "HelloMurder";

        public void Initialize()
        {
            // Just some values to play around with rendering and window
            //var a = Game.Instance.Window;
            //var b = Game.GraphicsDevice.DisplayMode.AspectRatio;

            Game.Data.CurrentPalette = Palette.Colors.ToImmutableArray();

            // Registers Movement Axis Input
            GamepadAxis[] stick =
            {
                GamepadAxis.LeftThumb,
                GamepadAxis.Dpad
            };

            // Registers movement from left stick or dpad
            Game.Input.RegisterAxes(MurderInputAxis.Movement, stick);

            // Registeres movement from wasd and arrow keys
            Game.Input.Register(MurderInputAxis.Movement,
                new InputButtonAxis(Keys.W, Keys.A, Keys.S, Keys.D),
                new InputButtonAxis(Keys.Up, Keys.Left, Keys.Down, Keys.Right));

            // Registers movement for the UI with wasd and arrow keys
            Game.Input.Register(MurderInputAxis.Ui,
                new InputButtonAxis(Keys.W, Keys.A, Keys.S, Keys.D),
                new InputButtonAxis(Keys.Up, Keys.Left, Keys.Down, Keys.Right));

            Game.Input.Register(InputButtons.Attack, Keys.Z);
            Game.Input.Register(InputButtons.Attack, Buttons.X);
            Game.Input.Register(InputButtons.Attack, Keys.Space);
        }
    }
}
