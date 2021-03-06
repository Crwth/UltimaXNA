﻿/***************************************************************************
 *   LoginScene.cs
 *   Part of UltimaXNA: http://code.google.com/p/ultimaxna
 *   
 *   begin                : May 31, 2009
 *   email                : poplicola@ultimaxna.com
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using UltimaXNA.Client;
using UltimaXNA.UILegacy;
#endregion

namespace UltimaXNA.SceneManagement
{
    public class LoginScene : BaseScene
    {
        public LoginScene(Game game)
            : base(game, true)
        {
            if (UltimaClient.IsConnected)
                UltimaClient.Disconnect();
        }

        public override void Intitialize()
        {
            base.Intitialize();
            Gump g = UI.AddGump_Local(new UILegacy.ClientsideGumps.LoginGump(), 0, 0);
            ((UILegacy.ClientsideGumps.LoginGump)g).OnLogin += this.OnLogin;
            Entities.EntitiesCollection.Reset();
            ClientVars.EngineVars.Map = -1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Dispose()
        {
            UI.GetGump<UILegacy.ClientsideGumps.LoginGump>(0).Dispose();
            base.Dispose();
        }

        public void OnLogin(string server, int port, string account, string password)
        {
            SceneManager.CurrentScene = new LoggingInScene(Game, server, port, account, password);
        }
    }
}
