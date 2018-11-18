// ts2fable 0.6.1
module Fable.Import.Popper
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

type [<StringEnum>] [<RequireQualifiedAccess>] Position =
    | Top
    | Right
    | Bottom
    | Left

and [<StringEnum>] [<RequireQualifiedAccess>] Placement =
    | [<CompiledName "auto-start">] AutoStart
    | Auto
    | [<CompiledName "auto-end">] AutoEnd
    | [<CompiledName "top-start">] TopStart
    | Top
    | [<CompiledName "top-end">] TopEnd
    | [<CompiledName "right-start">] RightStart
    | Right
    | [<CompiledName "right-end">] RightEnd
    | [<CompiledName "bottom-end">] BottomEnd
    | Bottom
    | [<CompiledName "bottom-start">] BottomStart
    | [<CompiledName "left-end">] LeftEnd
    | Left
    | [<CompiledName "left-start">] LeftStart

and [<StringEnum>] [<RequireQualifiedAccess>] Boundary =
    | ScrollParent
    | Viewport
    | Window

and [<StringEnum>] [<RequireQualifiedAccess>] Behavior =
    | Flip
    | Clockwise
    | Counterclockwise

and [<AllowNullLiteral>] ModifierFn =
    [<Emit "$0($1...)">] abstract Invoke: data: Data * options: Object -> Data

and [<AllowNullLiteral>] BaseModifier =
    abstract order: float option with get, set
    abstract enabled: bool option with get, set
    abstract fn: ModifierFn option with get, set

and [<AllowNullLiteral>] Modifiers =
    abstract shift: BaseModifier option with get, set
    abstract offset: obj option with get, set
    abstract preventOverflow: obj option with get, set
    abstract keepTogether: BaseModifier option with get, set
    abstract arrow: obj option with get, set
    abstract flip: obj option with get, set
    abstract inner: BaseModifier option with get, set
    abstract hide: BaseModifier option with get, set
    abstract applyStyle: obj option with get, set
    abstract computeStyle: obj option with get, set
    [<Emit "$0[$1]{{=$2}}">] abstract Item: name: string -> obj option with get, set

and [<AllowNullLiteral>] Offset =
    abstract top: float with get, set
    abstract left: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set

and [<AllowNullLiteral>] Data =
    abstract instance: Popper with get, set
    abstract placement: Placement with get, set
    abstract originalPlacement: Placement with get, set
    abstract flipped: bool with get, set
    abstract hide: bool with get, set
    abstract arrowElement: Element with get, set
    abstract styles: CSSStyleDeclaration with get, set
    abstract arrowStyles: CSSStyleDeclaration with get, set
    abstract boundaries: Object with get, set
    abstract offsets: obj with get, set

and [<AllowNullLiteral>] PopperOptions =
    abstract placement: Placement option with get, set
    abstract positionFixed: bool option with get, set
    abstract eventsEnabled: bool option with get, set
    abstract modifiers: Modifiers option with get, set
    abstract removeOnDestroy: bool option with get, set
    abstract onCreate: data: Data -> unit
    abstract onUpdate: data: Data -> unit

and [<AllowNullLiteral>] ReferenceObject =
    abstract clientHeight: float with get, set
    abstract clientWidth: float with get, set
    abstract getBoundingClientRect: unit -> ClientRect

/// This kind of namespace declaration is not necessary, but is kept here for backwards-compatibility with
/// popper.js 1.x. It can be removed in 2.x so that the default export is simply the Popper class
/// and all the ands / interfaces are top-level named exports.
and [<AllowNullLiteral>] [<Import("Popper","Popper")>] Popper =
    abstract modifiers: ResizeArray<obj> with get, set
    abstract placements: ResizeArray<Placement> with get, set
    abstract Defaults: PopperOptions with get, set
    abstract options: PopperOptions with get, set
    abstract destroy: unit -> unit
    abstract update: unit -> unit
    abstract scheduleUpdate: unit -> unit
    abstract enableEventListeners: unit -> unit
    abstract disableEventListeners: unit -> unit

/// This kind of namespace declaration is not necessary, but is kept here for backwards-compatibility with
/// popper.js 1.x. It can be removed in 2.x so that the default export is simply the Popper class
/// and all the ands / interfaces are top-level named exports.
and [<AllowNullLiteral>] PopperStatic =
    [<Emit "new $0($1...)">] abstract Create: reference: U2<Element, ReferenceObject> * popper: Element * ?options: PopperOptions -> Popper