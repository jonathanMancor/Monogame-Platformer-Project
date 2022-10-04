using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Core
{
    internal abstract class Component
    {
        internal abstract void LoadContent(ContentManager Content);
        internal abstract void Update(GameTime gameTime);

        internal abstract void Draw(SpriteBatch spriteBatch);

    }
}
