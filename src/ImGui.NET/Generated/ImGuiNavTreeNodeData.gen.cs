using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiNavTreeNodeData
    {
        public uint ID;
        public nint InFlags;
        public ImRect NavRect;
    }
    public unsafe partial struct ImGuiNavTreeNodeDataPtr
    {
        public ImGuiNavTreeNodeData* NativePtr { get; }
        public ImGuiNavTreeNodeDataPtr(ImGuiNavTreeNodeData* nativePtr) => NativePtr = nativePtr;
        public ImGuiNavTreeNodeDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiNavTreeNodeData*)nativePtr;
        public static implicit operator ImGuiNavTreeNodeDataPtr(ImGuiNavTreeNodeData* nativePtr) => new ImGuiNavTreeNodeDataPtr(nativePtr);
        public static implicit operator ImGuiNavTreeNodeData* (ImGuiNavTreeNodeDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiNavTreeNodeDataPtr(IntPtr nativePtr) => new ImGuiNavTreeNodeDataPtr(nativePtr);
        public static implicit operator IntPtr(ImGuiNavTreeNodeDataPtr self) => (IntPtr)self.NativePtr;
        public ref uint ID => ref Unsafe.AsRef<uint>(&NativePtr->ID);
        public ref nint InFlags => ref Unsafe.AsRef<nint>(&NativePtr->InFlags);
        public ref ImRect NavRect => ref Unsafe.AsRef<ImRect>(&NativePtr->NavRect);
    }
}
