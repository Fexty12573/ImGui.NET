using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiFocusScopeData
    {
        public uint ID;
        public uint WindowID;
    }
    public unsafe partial struct ImGuiFocusScopeDataPtr
    {
        public ImGuiFocusScopeData* NativePtr { get; }
        public ImGuiFocusScopeDataPtr(ImGuiFocusScopeData* nativePtr) => NativePtr = nativePtr;
        public ImGuiFocusScopeDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiFocusScopeData*)nativePtr;
        public static implicit operator ImGuiFocusScopeDataPtr(ImGuiFocusScopeData* nativePtr) => new ImGuiFocusScopeDataPtr(nativePtr);
        public static implicit operator ImGuiFocusScopeData* (ImGuiFocusScopeDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiFocusScopeDataPtr(IntPtr nativePtr) => new ImGuiFocusScopeDataPtr(nativePtr);
        public static implicit operator IntPtr(ImGuiFocusScopeDataPtr self) => (IntPtr)self.NativePtr;
        public ref uint ID => ref Unsafe.AsRef<uint>(&NativePtr->ID);
        public ref uint WindowID => ref Unsafe.AsRef<uint>(&NativePtr->WindowID);
    }
}
