using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe struct ImSpanUnknown
    {
        public IntPtr Begin;
        public IntPtr End;
    }

    public unsafe struct ImBitArrayForNamedKeys
    {
        public fixed uint Storage[((int)ImGuiKey.NamedKey_COUNT + 31) >> 5];
    }

    public unsafe struct ImChunkStream
    {
        public ImVector Buf;
    }

    public unsafe struct ImGuiDirPtr
    {
        public ImGuiDir* NativePtr;
    }

    public unsafe struct ImGuiDockRequestPtr
    {
        public IntPtr Pointer;
    }
    public unsafe struct ImGuiDockNodeSettingsPtr
    {
        public ImGuiDir* NativePtr;
    }
    
    public unsafe struct ImGuiErrorLogCallback
    {
        public IntPtr FnPtr;
    }

    public unsafe struct ImGuiContextHookCallback
    {
        public IntPtr FnPtr;
    }
    public unsafe struct ImPoolUnknown
    {
        public ImVector Buf;
        ImGuiStorage Map;
        nint FreeIdx;
        nint AliveCount;
    }

}