﻿/**
 * DCPU-16 ASM.NET
 * Copyright (c) 2012 Tim "DensitY" Hancock (densitynz@orcon.net.nz)
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace dcpu16_ASM
{
    /// <summary>
    /// DCPU-16 Op codes, Unless extra bytes are required op codes are generally stored
    /// bbbbbbaaaaaaoooo
    /// 
    /// O = 4bits for cpu OpCode
    /// A = 6bits for Dest Param
    /// B = 6bits for Source Param 
    /// 
    /// Depending on parm, up to 2 extra words may be required (meaning max instruction length is 3 words long)
    /// </summary>
    public enum dcpuOpCode : ushort
    {
        NB_OP = 0x0,      // Signals non basic instruction

        SET_OP = 0x1,      // Set instruciton          -> A = B 
        ADD_OP = 0x2,      // Add instruction          -> A = A + B
        SUB_OP = 0x3,      // Subtract instruciton     -> A = A - B
        MUL_OP = 0x4,      // Muliply  instruction     -> A = A * B
        DIV_OP = 0x5,      // Divide instruction       -> A = A / B
        MOD_OP = 0x6,      // Modulate instruction     -> A = A % B
        SHL_OP = 0x7,      // Shift Left instruction   -> A = A << B
        SHR_OP = 0x8,      // Shift right instruction  -> A = A >> B
        AND_OP = 0x9,      // Boolean AND instruction  -> A = A & B
        BOR_OP = 0xA,      // Boolean OR instruction   -> A = A | B
        XOR_OP = 0xB,      // Boolean XOR instruction  -> A = A ^ B
        IFE_OP = 0xC,      // Branch! if(A == B) run next instruction
        IFN_OP = 0xD,      // Branch! if(A != B) run next instruction
        IFG_OP = 0xE,      // Branch! if(A > B) run next instruction
        IFB_OP = 0xF,      // Branch! if((A & B) != 0) run next instruction

        // Non basic instructions
        // Encoded as follows
        // AAAAAAoooooo0000 
        // Basically unlike basic instructions, we lose a register spot and use that for the op code.
        // the old op code is zeroed out (which signals a non basic instruction). This means 
        // any non basic instruction, even if its something like derp X, Y will use 2 words (unlike a basic instruction in that case)
        JSR_OP = 0x10
    }
}
