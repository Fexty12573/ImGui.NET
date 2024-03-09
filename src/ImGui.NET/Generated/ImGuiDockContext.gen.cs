using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiDockContext
    {
        public ImGuiStorage Nodes;
        public ImVector Requests;
        public ImVector NodesSettings;
        public byte WantFullRebuild;
    }
    public unsafe partial struct ImGuiDockContextPtr
    {
        public ImGuiDockContext* NativePtr { get; }
        public ImGuiDockContextPtr(ImGuiDockContext* nativePtr) => NativePtr = nativePtr;
        public ImGuiDockContextPtr(IntPtr nativePtr) => NativePtr = (ImGuiDockContext*)nativePtr;
        public static implicit operator ImGuiDockContextPtr(ImGuiDockContext* nativePtr) => new ImGuiDockContextPtr(nativePtr);
        public static implicit operator ImGuiDockContext* (ImGuiDockContextPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiDockContextPtr(IntPtr nativePtr) => new ImGuiDockContextPtr(nativePtr);
        public static implicit operator IntPtr(ImGuiDockContextPtr self) => (IntPtr)self.NativePtr;
    }
}
