﻿/***************************************************************************
 *   UpdateStaminaPacket.cs
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
using UltimaXNA.Network;
#endregion

namespace UltimaXNA.Client.Packets.Server
{
    public class UpdateStaminaPacket : RecvPacket
    {
        readonly Serial _serial;
        readonly short _current;
        readonly short _max;

        public Serial Serial
        {
            get { return _serial; }
        }

        public short Current
        {
            get { return _current; }
        }

        public short Max
        {
            get { return _max; } 
        }
        
        public UpdateStaminaPacket(PacketReader reader)
            : base(0xA3, "Update Stamina")
        {
            _serial = reader.ReadInt32();
            _max = reader.ReadInt16();
            _current = reader.ReadInt16();
        }
    }
}
