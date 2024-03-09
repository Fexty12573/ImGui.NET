using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiTableCellData
    {
        public uint BgColor;
        public short Column;
    }
    public unsafe partial struct ImGuiTableCellDataPtr
    {
        public ImGuiTableCellData* NativePtr { get; }
        public ImGuiTableCellDataPtr(ImGuiTableCellData* nativePtr) => NativePtr = nativePtr;
        public ImGuiTableCellDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiTableCellData*)nativePtr;
        public static implicit operator ImGuiTableCellDataPtr(ImGuiTableCellData* nativePtr) => new ImGuiTableCellDataPtr(nativePtr);
        public static implicit operator ImGuiTableCellData* (ImGuiTableCellDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiTableCellDataPtr(IntPtr nativePtr) => new ImGuiTableCellDataPtr(nativePtr);
        public static implicit operator IntPtr(ImGuiTableCellDataPtr self) => (IntPtr)self.NativePtr;
        public ref uint BgColor => ref Unsafe.AsRef<uint>(&NativePtr->BgColor);
        public ref short Column => ref Unsafe.AsRef<short>(&NativePtr->Column);
    }
}
