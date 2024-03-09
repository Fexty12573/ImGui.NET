using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiIDStackTool
    {
        public int LastActiveFrame;
        public int StackLevel;
        public uint QueryId;
        public ImVector Results;
        public byte CopyToClipboardOnCtrlC;
        public float CopyToClipboardLastTime;
    }
    public unsafe partial struct ImGuiIDStackToolPtr
    {
        public ImGuiIDStackTool* NativePtr { get; }
        public ImGuiIDStackToolPtr(ImGuiIDStackTool* nativePtr) => NativePtr = nativePtr;
        public ImGuiIDStackToolPtr(IntPtr nativePtr) => NativePtr = (ImGuiIDStackTool*)nativePtr;
        public static implicit operator ImGuiIDStackToolPtr(ImGuiIDStackTool* nativePtr) => new ImGuiIDStackToolPtr(nativePtr);
        public static implicit operator ImGuiIDStackTool* (ImGuiIDStackToolPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiIDStackToolPtr(IntPtr nativePtr) => new ImGuiIDStackToolPtr(nativePtr);
        public static implicit operator IntPtr(ImGuiIDStackToolPtr self) => (IntPtr)self.NativePtr;
        public ref int LastActiveFrame => ref Unsafe.AsRef<int>(&NativePtr->LastActiveFrame);
        public ref int StackLevel => ref Unsafe.AsRef<int>(&NativePtr->StackLevel);
        public ref uint QueryId => ref Unsafe.AsRef<uint>(&NativePtr->QueryId);
        public ImPtrVector<ImGuiStackLevelInfoPtr> Results => new ImPtrVector<ImGuiStackLevelInfoPtr>(NativePtr->Results, Unsafe.SizeOf<ImGuiStackLevelInfo>());
        public ref bool CopyToClipboardOnCtrlC => ref Unsafe.AsRef<bool>(&NativePtr->CopyToClipboardOnCtrlC);
        public ref float CopyToClipboardLastTime => ref Unsafe.AsRef<float>(&NativePtr->CopyToClipboardLastTime);
        public void Destroy()
        {
            ImGuiNative.ImGuiIDStackTool_destroy((ImGuiIDStackTool*)(NativePtr));
        }
    }
}
