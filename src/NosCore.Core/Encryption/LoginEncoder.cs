﻿using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NosCore.Core.Encryption
{
    public class LoginEncoder : MessageToMessageEncoder<string>, IEncoder
    {
        protected override void Encode(IChannelHandlerContext context, string message, List<object> output)
        {
            try
            {
                byte[] tmp = Encoding.Default.GetBytes(message);
                for (int i = 0; i < message.Length; i++)
                {
                    tmp[i] = Convert.ToByte(tmp[i] + 15);
                }
                tmp[tmp.Length - 1] = 25;
                if (tmp.Length == 0)
                {
                    return;
                }
                output.Add(Unpooled.WrappedBuffer(tmp)); 
            }
            catch
            {
               
            }
        }
    }
}