// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do one of these:
//
//    using QuickType;
//
//    var fileResponse = FileResponse.FromJson(jsonString);
//    var commentsResponse = CommentsResponse.FromJson(jsonString);
//    var commentRequest = CommentRequest.FromJson(jsonString);
//    var projectsResponse = ProjectsResponse.FromJson(jsonString);
//    var projectFilesResponse = ProjectFilesResponse.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FileResponse
    {
        /// <summary>
        /// Node Properties
        /// The root node
        /// The root node within the document
        /// </summary>
        [JsonProperty("document")]
        public Document Document { get; set; }

        /// <summary>
        /// A mapping from node IDs to component metadata. This is to help you determine which
        /// components each instance comes from. Currently the only piece of metadata available on
        /// components is the name of the component, but more properties will be forthcoming.
        /// </summary>
        [JsonProperty("components")]
        public Dictionary<string, Component> Components { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("schemaVersion")]
        public double SchemaVersion { get; set; }
    }

    /// <summary>
    /// A node that can have instances created of it that share the same properties
    /// </summary>
    public partial class Component
    {
        /// <summary>
        /// An array of effects attached to this node
        /// (see effects sectionfor more details)
        /// </summary>
        [JsonProperty("effects")]
        public Effect[] Effects { get; set; }

        /// <summary>
        /// An array of layout grids attached to this node (see layout grids section
        /// for more details). GROUP nodes do not have this attribute
        /// </summary>
        [JsonProperty("layoutGrids")]
        public LayoutGrid[] LayoutGrids { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("opacity")]
        public double Opacity { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Bounding box of the node in absolute space coordinates
        /// A rectangle
        /// </summary>
        [JsonProperty("absoluteBoundingBox")]
        public Rectangle AbsoluteBoundingBox { get; set; }

        /// <summary>
        /// Node ID of node to transition to in prototyping
        /// </summary>
        [JsonProperty("transitionNodeID")]
        public string TransitionNodeId { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Enum describing how layer blends with layers below
        /// This type is a string enum with the following possible values
        /// How this node blends with nodes behind it in the scene
        /// (see blend mode section for more details)
        /// </summary>
        [JsonProperty("blendMode")]
        public BlendMode BlendMode { get; set; }

        /// <summary>
        /// Background color of the node
        /// An RGBA color
        /// Solid color of the paint
        /// Color attached to corresponding position
        /// Color of the grid
        /// Background color of the canvas
        /// </summary>
        [JsonProperty("backgroundColor")]
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Horizontal and vertical layout constraints for node
        /// Layout constraint relative to containing Frame
        /// </summary>
        [JsonProperty("constraints")]
        public LayoutConstraint Constraints { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("isMask")]
        public bool IsMask { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("clipsContent")]
        public bool ClipsContent { get; set; }

        /// <summary>
        /// An array of export settings representing images to export from node
        /// An array of export settings representing images to export from this node
        /// An array of export settings representing images to export from the canvas
        /// </summary>
        [JsonProperty("exportSettings")]
        public ExportSetting[] ExportSettings { get; set; }

        /// <summary>
        /// the type of the node, refer to table below for details
        /// </summary>
        [JsonProperty("type")]
        public NodeType Type { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("preserveRatio")]
        public bool PreserveRatio { get; set; }

        /// <summary>
        /// An array of nodes that are direct children of this node
        /// An array of nodes that are being boolean operated on
        /// An array of top level layers on the canvas
        /// An array of canvases attached to the document
        /// </summary>
        [JsonProperty("children")]
        public Node[] Children { get; set; }
    }

    /// <summary>
    /// Bounding box of the node in absolute space coordinates
    /// A rectangle
    /// </summary>
    public partial class Rectangle
    {
        /// <summary>
        /// An array of effects attached to this node
        /// (see effects sectionfor more details)
        /// </summary>
        [JsonProperty("effects")]
        public Effect[] Effects { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("cornerRadius")]
        public double CornerRadius { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("opacity")]
        public double Opacity { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Where stroke is drawn relative to the vector outline as a string enum
        /// "INSIDE": draw stroke inside the shape boundary
        /// "OUTSIDE": draw stroke outside the shape boundary
        /// "CENTER": draw stroke centered along the shape boundary
        /// </summary>
        [JsonProperty("strokeAlign")]
        public StrokeAlign StrokeAlign { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("strokeWeight")]
        public double StrokeWeight { get; set; }

        /// <summary>
        /// An array of fill paints applied to the node
        /// An array of stroke paints applied to the node
        /// Paints applied to characters
        /// </summary>
        [JsonProperty("fills")]
        public Paint[] Fills { get; set; }

        /// <summary>
        /// Bounding box of the node in absolute space coordinates
        /// A rectangle
        /// </summary>
        [JsonProperty("absoluteBoundingBox")]
        public Rectangle AbsoluteBoundingBox { get; set; }

        /// <summary>
        /// Node ID of node to transition to in prototyping
        /// </summary>
        [JsonProperty("transitionNodeID")]
        public string TransitionNodeId { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Enum describing how layer blends with layers below
        /// This type is a string enum with the following possible values
        /// How this node blends with nodes behind it in the scene
        /// (see blend mode section for more details)
        /// </summary>
        [JsonProperty("blendMode")]
        public BlendMode BlendMode { get; set; }

        /// <summary>
        /// Horizontal and vertical layout constraints for node
        /// Layout constraint relative to containing Frame
        /// </summary>
        [JsonProperty("constraints")]
        public LayoutConstraint Constraints { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("isMask")]
        public bool IsMask { get; set; }

        /// <summary>
        /// An array of export settings representing images to export from node
        /// An array of export settings representing images to export from this node
        /// An array of export settings representing images to export from the canvas
        /// </summary>
        [JsonProperty("exportSettings")]
        public ExportSetting[] ExportSettings { get; set; }

        /// <summary>
        /// the type of the node, refer to table below for details
        /// </summary>
        [JsonProperty("type")]
        public NodeType Type { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// An array of fill paints applied to the node
        /// An array of stroke paints applied to the node
        /// Paints applied to characters
        /// </summary>
        [JsonProperty("strokes")]
        public Paint[] Strokes { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("preserveRatio")]
        public bool PreserveRatio { get; set; }
    }

    /// <summary>
    /// Horizontal and vertical layout constraints for node
    /// Layout constraint relative to containing Frame
    /// </summary>
    public partial class LayoutConstraint
    {
        /// <summary>
        /// Vertical constraint as an enum
        /// "TOP": Node is laid out relative to top of the containing frame
        /// "BOTTOM": Node is laid out relative to bottom of the containing frame
        /// "CENTER": Node is vertically centered relative to containing frame
        /// "TOP_BOTTOM": Both top and bottom of node are constrained relative to containing frame
        /// (node stretches with frame)
        /// "SCALE": Node scales vertically with containing frame
        /// </summary>
        [JsonProperty("vertical")]
        public Vertical Vertical { get; set; }

        /// <summary>
        /// Horizontal constraint as an enum
        /// "LEFT": Node is laid out relative to left of the containing frame
        /// "RIGHT": Node is laid out relative to right of the containing frame
        /// "CENTER": Node is horizontally centered relative to containing frame
        /// "LEFT_RIGHT": Both left and right of node are constrained relative to containing frame
        /// (node stretches with frame)
        /// "SCALE": Node scales horizontally with containing frame
        /// </summary>
        [JsonProperty("horizontal")]
        public Horizontal Horizontal { get; set; }
    }

    /// <summary>
    /// An array of effects attached to this node
    /// (see effects sectionfor more details)
    /// A visual effect such as a shadow or blur
    /// </summary>
    public partial class Effect
    {
        /// <summary>
        /// Type of effect as a string enum
        /// </summary>
        [JsonProperty("type")]
        public EffectType Type { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("radius")]
        public double Radius { get; set; }

        /// <summary>
        /// Background color of the node
        /// An RGBA color
        /// Solid color of the paint
        /// Color attached to corresponding position
        /// Color of the grid
        /// Background color of the canvas
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// Enum describing how layer blends with layers below
        /// This type is a string enum with the following possible values
        /// How this node blends with nodes behind it in the scene
        /// (see blend mode section for more details)
        /// </summary>
        [JsonProperty("blendMode")]
        public BlendMode? BlendMode { get; set; }

        /// <summary>
        /// 2d vector offset within the frame.
        /// A 2d vector
        /// This field contains three vectors, each of which are a position in
        /// normalized object space (normalized object space is if the top left
        /// corner of the bounding box of the object is (0, 0) and the bottom
        /// right is (1,1)). The first position corresponds to the start of the
        /// gradient (value 0 for the purposes of calculating gradient stops),
        /// the second position is the end of the gradient (value 1), and the
        /// third handle position determines the width of the gradient (only
        /// relevant for non-linear gradients).
        /// </summary>
        [JsonProperty("offset")]
        public Vector2 Offset { get; set; }
    }

    /// <summary>
    /// Background color of the node
    /// An RGBA color
    /// Solid color of the paint
    /// Color attached to corresponding position
    /// Color of the grid
    /// Background color of the canvas
    /// </summary>
    public partial class Color
    {
        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("r")]
        public double R { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("g")]
        public double G { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("b")]
        public double B { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("a")]
        public double A { get; set; }
    }

    /// <summary>
    /// 2d vector offset within the frame.
    /// A 2d vector
    /// This field contains three vectors, each of which are a position in
    /// normalized object space (normalized object space is if the top left
    /// corner of the bounding box of the object is (0, 0) and the bottom
    /// right is (1,1)). The first position corresponds to the start of the
    /// gradient (value 0 for the purposes of calculating gradient stops),
    /// the second position is the end of the gradient (value 1), and the
    /// third handle position determines the width of the gradient (only
    /// relevant for non-linear gradients).
    /// </summary>
    public partial class Vector2
    {
        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }
    }

    /// <summary>
    /// An array of export settings representing images to export from node
    /// Format and size to export an asset at
    /// An array of export settings representing images to export from the canvas
    /// An array of export settings representing images to export from this node
    /// </summary>
    public partial class ExportSetting
    {
        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// Image type, string enum
        /// </summary>
        [JsonProperty("format")]
        public Format Format { get; set; }

        /// <summary>
        /// Constraint that determines sizing of exported asset
        /// Sizing constraint for exports
        /// </summary>
        [JsonProperty("constraint")]
        public Constraint Constraint { get; set; }
    }

    /// <summary>
    /// Constraint that determines sizing of exported asset
    /// Sizing constraint for exports
    /// </summary>
    public partial class Constraint
    {
        /// <summary>
        /// Type of constraint to apply; string enum with potential values below
        /// "SCALE": Scale by value
        /// "WIDTH": Scale proportionally and set width to value
        /// "HEIGHT": Scale proportionally and set height to value
        /// </summary>
        [JsonProperty("type")]
        public ConstraintType Type { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("value")]
        public double Value { get; set; }
    }

    /// <summary>
    /// An array of fill paints applied to the node
    /// A solid color, gradient, or image texture that can be applied as fills or strokes
    /// An array of stroke paints applied to the node
    /// Paints applied to characters
    /// </summary>
    public partial class Paint
    {
        /// <summary>
        /// Type of paint as a string enum
        /// </summary>
        [JsonProperty("type")]
        public PaintType Type { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("opacity")]
        public double Opacity { get; set; }

        /// <summary>
        /// Background color of the node
        /// An RGBA color
        /// Solid color of the paint
        /// Color attached to corresponding position
        /// Color of the grid
        /// Background color of the canvas
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// This field contains three vectors, each of which are a position in
        /// normalized object space (normalized object space is if the top left
        /// corner of the bounding box of the object is (0, 0) and the bottom
        /// right is (1,1)). The first position corresponds to the start of the
        /// gradient (value 0 for the purposes of calculating gradient stops),
        /// the second position is the end of the gradient (value 1), and the
        /// third handle position determines the width of the gradient (only
        /// relevant for non-linear gradients).
        /// </summary>
        [JsonProperty("gradientHandlePositions")]
        public Vector2[] GradientHandlePositions { get; set; }

        /// <summary>
        /// Positions of key points along the gradient axis with the colors
        /// anchored there. Colors along the gradient are interpolated smoothly
        /// between neighboring gradient stops.
        /// </summary>
        [JsonProperty("gradientStops")]
        public ColorStop[] GradientStops { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("scaleMode")]
        public string ScaleMode { get; set; }
    }

    /// <summary>
    /// Positions of key points along the gradient axis with the colors
    /// anchored there. Colors along the gradient are interpolated smoothly
    /// between neighboring gradient stops.
    /// A position color pair representing a gradient stop
    /// </summary>
    public partial class ColorStop
    {
        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("position")]
        public double Position { get; set; }

        /// <summary>
        /// Background color of the node
        /// An RGBA color
        /// Solid color of the paint
        /// Color attached to corresponding position
        /// Color of the grid
        /// Background color of the canvas
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }
    }

    /// <summary>
    /// An array of nodes that are direct children of this node
    /// An array of nodes that are being boolean operated on
    /// An array of top level layers on the canvas
    /// An array of canvases attached to the document
    /// Node Properties
    /// The root node
    /// The root node within the document
    /// Represents a single page
    /// A node of fixed size containing other nodes
    /// A logical grouping of nodes
    /// A vector network, consisting of vertices and edges
    /// A group that has a boolean operation applied to it
    /// A regular star shape
    /// A straight line
    /// An ellipse
    /// A regular n-sided polygon
    /// Bounding box of the node in absolute space coordinates
    /// A rectangle
    /// A text box
    /// A rectangular region of the canvas that can be exported
    /// A node that can have instances created of it that share the same properties
    /// An instance of a component, changes to the component result in the same
    /// changes applied to the instance
    /// </summary>
    public partial class Node
    {
        /// <summary>
        /// An array of effects attached to this node
        /// (see effects sectionfor more details)
        /// </summary>
        [JsonProperty("effects")]
        public Effect[] Effects { get; set; }

        /// <summary>
        /// An array of layout grids attached to this node (see layout grids section
        /// for more details). GROUP nodes do not have this attribute
        /// </summary>
        [JsonProperty("layoutGrids")]
        public LayoutGrid[] LayoutGrids { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("cornerRadius")]
        public double? CornerRadius { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("characters")]
        public string Characters { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("opacity")]
        public double? Opacity { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Where stroke is drawn relative to the vector outline as a string enum
        /// "INSIDE": draw stroke inside the shape boundary
        /// "OUTSIDE": draw stroke outside the shape boundary
        /// "CENTER": draw stroke centered along the shape boundary
        /// </summary>
        [JsonProperty("strokeAlign")]
        public StrokeAlign? StrokeAlign { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("strokeWeight")]
        public double? StrokeWeight { get; set; }

        /// <summary>
        /// An array of fill paints applied to the node
        /// An array of stroke paints applied to the node
        /// Paints applied to characters
        /// </summary>
        [JsonProperty("fills")]
        public Paint[] Fills { get; set; }

        /// <summary>
        /// Bounding box of the node in absolute space coordinates
        /// A rectangle
        /// </summary>
        [JsonProperty("absoluteBoundingBox")]
        public Rectangle AbsoluteBoundingBox { get; set; }

        /// <summary>
        /// Map from ID to TypeStyle for looking up style overrides
        /// </summary>
        [JsonProperty("styleOverrideTable")]
        public TypeStyle[] StyleOverrideTable { get; set; }

        /// <summary>
        /// Map from ID to TypeStyle for looking up style overrides
        /// Metadata for character formatting
        /// Style of text including font family and weight (see type style
        /// section for more information)
        /// </summary>
        [JsonProperty("style")]
        public TypeStyle Style { get; set; }

        /// <summary>
        /// Node ID of node to transition to in prototyping
        /// </summary>
        [JsonProperty("transitionNodeID")]
        public string TransitionNodeId { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Enum describing how layer blends with layers below
        /// This type is a string enum with the following possible values
        /// How this node blends with nodes behind it in the scene
        /// (see blend mode section for more details)
        /// </summary>
        [JsonProperty("blendMode")]
        public BlendMode? BlendMode { get; set; }

        /// <summary>
        /// Background color of the node
        /// An RGBA color
        /// Solid color of the paint
        /// Color attached to corresponding position
        /// Color of the grid
        /// Background color of the canvas
        /// </summary>
        [JsonProperty("backgroundColor")]
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Horizontal and vertical layout constraints for node
        /// Layout constraint relative to containing Frame
        /// </summary>
        [JsonProperty("constraints")]
        public LayoutConstraint Constraints { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("isMask")]
        public bool? IsMask { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("clipsContent")]
        public bool? ClipsContent { get; set; }

        /// <summary>
        /// An array of export settings representing images to export from node
        /// An array of export settings representing images to export from this node
        /// An array of export settings representing images to export from the canvas
        /// </summary>
        [JsonProperty("exportSettings")]
        public ExportSetting[] ExportSettings { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("componentId")]
        public string ComponentId { get; set; }

        /// <summary>
        /// the type of the node, refer to table below for details
        /// </summary>
        [JsonProperty("type")]
        public NodeType Type { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// An array of fill paints applied to the node
        /// An array of stroke paints applied to the node
        /// Paints applied to characters
        /// </summary>
        [JsonProperty("strokes")]
        public Paint[] Strokes { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("preserveRatio")]
        public bool? PreserveRatio { get; set; }

        /// <summary>
        /// An array of nodes that are direct children of this node
        /// An array of nodes that are being boolean operated on
        /// An array of top level layers on the canvas
        /// An array of canvases attached to the document
        /// </summary>
        [JsonProperty("children")]
        public Node[] Children { get; set; }

        /// <summary>
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// </summary>
        [JsonProperty("characterStyleOverrides")]
        public double[] CharacterStyleOverrides { get; set; }
    }

    /// <summary>
    /// An array of layout grids attached to this node (see layout grids section
    /// for more details). GROUP nodes do not have this attribute
    /// Guides to align and place objects within a frame
    /// </summary>
    public partial class LayoutGrid
    {
        /// <summary>
        /// Orientation of the grid as a string enum
        /// "COLUMNS": Vertical grid
        /// "ROWS": Horizontal grid
        /// "GRID": Square grid
        /// </summary>
        [JsonProperty("pattern")]
        public Pattern Pattern { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("sectionSize")]
        public double SectionSize { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Background color of the node
        /// An RGBA color
        /// Solid color of the paint
        /// Color attached to corresponding position
        /// Color of the grid
        /// Background color of the canvas
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// Positioning of grid as a string enum
        /// "MIN": Grid starts at the left or top of the frame
        /// "MAX": Grid starts at the right or bottom of the frame
        /// "CENTER": Grid is center aligned
        /// </summary>
        [JsonProperty("alignment")]
        public Alignment Alignment { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("gutterSize")]
        public double GutterSize { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("offset")]
        public double Offset { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("count")]
        public double Count { get; set; }
    }

    /// <summary>
    /// Map from ID to TypeStyle for looking up style overrides
    /// Metadata for character formatting
    /// Style of text including font family and weight (see type style
    /// section for more information)
    /// </summary>
    public partial class TypeStyle
    {
        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("lineHeightPx")]
        public double LineHeightPx { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("fontPostScriptName")]
        public string FontPostScriptName { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("fontWeight")]
        public double FontWeight { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("lineHeightPercent")]
        public double LineHeightPercent { get; set; }

        /// <summary>
        /// Vertical text alignment as string enum
        /// </summary>
        [JsonProperty("textAlignVertical")]
        public TextAlignVertical TextAlignVertical { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("fontSize")]
        public double FontSize { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("italic")]
        public bool Italic { get; set; }

        /// <summary>
        /// An array of fill paints applied to the node
        /// An array of stroke paints applied to the node
        /// Paints applied to characters
        /// </summary>
        [JsonProperty("fills")]
        public Paint[] Fills { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        /// <summary>
        /// Horizontal text alignment as string enum
        /// </summary>
        [JsonProperty("textAlignHorizontal")]
        public TextAlignHorizontal TextAlignHorizontal { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("letterSpacing")]
        public double LetterSpacing { get; set; }
    }

    /// <summary>
    /// Node Properties
    /// The root node
    /// The root node within the document
    /// </summary>
    public partial class Document
    {
        /// <summary>
        /// An array of nodes that are direct children of this node
        /// An array of nodes that are being boolean operated on
        /// An array of top level layers on the canvas
        /// An array of canvases attached to the document
        /// </summary>
        [JsonProperty("children")]
        public Node[] Children { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Is the effect active?
        /// Is the grid currently visible?
        /// Is the paint enabled?
        /// whether or not the node is visible on the canvas
        /// Does this node mask sibling nodes in front of it?
        /// Keep height and width constrained to same ratio
        /// Does this node clip content outside of its bounds?
        /// Is text italicized?
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// the type of the node, refer to table below for details
        /// </summary>
        [JsonProperty("type")]
        public NodeType Type { get; set; }
    }

    public partial class CommentsResponse
    {
        [JsonProperty("comments")]
        public Comment[] Comments { get; set; }
    }

    /// <summary>
    /// A comment or reply left by a user
    /// </summary>
    public partial class Comment
    {
        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Enables basic storage and retrieval of dates and times.
        /// </summary>
        [JsonProperty("created_at")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// A description of a user
        /// The user who left the comment
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("order_id")]
        public double OrderId { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// 2d vector offset within the frame.
        /// A 2d vector
        /// This field contains three vectors, each of which are a position in
        /// normalized object space (normalized object space is if the top left
        /// corner of the bounding box of the object is (0, 0) and the bottom
        /// right is (1,1)). The first position corresponds to the start of the
        /// gradient (value 0 for the purposes of calculating gradient stops),
        /// the second position is the end of the gradient (value 1), and the
        /// third handle position determines the width of the gradient (only
        /// relevant for non-linear gradients).
        /// A relative offset within a frame
        /// </summary>
        [JsonProperty("client_meta")]
        public ClientMeta ClientMeta { get; set; }

        /// <summary>
        /// If set, when the comment was resolved
        /// </summary>
        [JsonProperty("resolved_at")]
        public System.DateTimeOffset? ResolvedAt { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("file_key")]
        public string FileKey { get; set; }
    }

    /// <summary>
    /// 2d vector offset within the frame.
    /// A 2d vector
    /// This field contains three vectors, each of which are a position in
    /// normalized object space (normalized object space is if the top left
    /// corner of the bounding box of the object is (0, 0) and the bottom
    /// right is (1,1)). The first position corresponds to the start of the
    /// gradient (value 0 for the purposes of calculating gradient stops),
    /// the second position is the end of the gradient (value 1), and the
    /// third handle position determines the width of the gradient (only
    /// relevant for non-linear gradients).
    /// A relative offset within a frame
    /// </summary>
    public partial class ClientMeta
    {
        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("x")]
        public double? X { get; set; }

        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("y")]
        public double? Y { get; set; }

        /// <summary>
        /// Unique id specifying the frame.
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// </summary>
        [JsonProperty("node_id")]
        public string[] NodeId { get; set; }

        /// <summary>
        /// 2d vector offset within the frame.
        /// A 2d vector
        /// This field contains three vectors, each of which are a position in
        /// normalized object space (normalized object space is if the top left
        /// corner of the bounding box of the object is (0, 0) and the bottom
        /// right is (1,1)). The first position corresponds to the start of the
        /// gradient (value 0 for the purposes of calculating gradient stops),
        /// the second position is the end of the gradient (value 1), and the
        /// third handle position determines the width of the gradient (only
        /// relevant for non-linear gradients).
        /// </summary>
        [JsonProperty("node_offset")]
        public Vector2 NodeOffset { get; set; }
    }

    /// <summary>
    /// A description of a user
    /// The user who left the comment
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("handle")]
        public string Handle { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("img_url")]
        public string ImgUrl { get; set; }
    }

    public partial class CommentRequest
    {
        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 2d vector offset within the frame.
        /// A 2d vector
        /// This field contains three vectors, each of which are a position in
        /// normalized object space (normalized object space is if the top left
        /// corner of the bounding box of the object is (0, 0) and the bottom
        /// right is (1,1)). The first position corresponds to the start of the
        /// gradient (value 0 for the purposes of calculating gradient stops),
        /// the second position is the end of the gradient (value 1), and the
        /// third handle position determines the width of the gradient (only
        /// relevant for non-linear gradients).
        /// A relative offset within a frame
        /// </summary>
        [JsonProperty("client_meta")]
        public ClientMeta ClientMeta { get; set; }
    }

    public partial class ProjectsResponse
    {
        [JsonProperty("projects")]
        public Project[] Projects { get; set; }
    }

    public partial class Project
    {
        /// <summary>
        /// X coordinate of the vector
        /// Y coordinate of the vector
        /// Radius of the blur effect (applies to shadows as well)
        /// Red channel value, between 0 and 1
        /// Green channel value, between 0 and 1
        /// Blue channel value, between 0 and 1
        /// Alpha channel value, between 0 and 1
        /// Width of column grid or height of row grid or square grid spacing
        /// Spacing in between columns and rows
        /// Spacing before the first column or row
        /// Number of columns or rows
        /// Opacity of the node
        /// Radius of each corner of the rectangle
        /// The weight of strokes on the node
        /// Overall opacity of paint (colors within the paint can also have opacity
        /// values which would blend with this)
        /// Value between 0 and 1 representing position along gradient axis
        /// See type property for effect of this field
        /// Line height in px
        /// Numeric font weight
        /// Line height as a percentage of normal line height
        /// Font size in px
        /// Space between characters in px
        /// Array with same number of elements as characeters in text box,
        /// each element is a reference to the styleOverrideTable defined
        /// below and maps to the corresponding character in the characters
        /// field. Elements with value 0 have the default type style
        /// Only set for top level comments. The number displayed with the
        /// comment in the UI
        /// </summary>
        [JsonProperty("id")]
        public double Id { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ProjectFilesResponse
    {
        [JsonProperty("files")]
        public File[] Files { get; set; }
    }

    public partial class File
    {
        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Allows manipulation and formatting of text strings and determination and location of
        /// substrings within strings.
        /// the name given to the node by the user in the tool.
        /// Image scaling mode
        /// File suffix to append to all filenames
        /// a string uniquely identifying this node within the document
        /// Text contained within text box
        /// PostScript font name
        /// Font family of text (standard name)
        /// ID of component that this instance came from, refers to components
        /// table (see endpoints section below)
        /// (MISSING IN DOCS)
        /// The content of the comment
        /// If present, the id of the comment to which this is the reply
        /// Unique identifier for comment
        /// The file in which the comment lives
        /// utc date in iso8601
        /// </summary>
        [JsonProperty("last_modified")]
        public string LastModified { get; set; }
    }

    /// <summary>
    /// Enum describing how layer blends with layers below
    /// This type is a string enum with the following possible values
    /// How this node blends with nodes behind it in the scene
    /// (see blend mode section for more details)
    /// </summary>
    public enum BlendMode { Color, ColorBurn, ColorDodge, Darken, Difference, Exclusion, HardLight, Hue, Lighten, LinearBurn, LinearDodge, Luminosity, Multiply, Normal, Overlay, PassThrough, Saturation, Screen, SoftLight };

    /// <summary>
    /// Horizontal constraint as an enum
    /// "LEFT": Node is laid out relative to left of the containing frame
    /// "RIGHT": Node is laid out relative to right of the containing frame
    /// "CENTER": Node is horizontally centered relative to containing frame
    /// "LEFT_RIGHT": Both left and right of node are constrained relative to containing frame
    /// (node stretches with frame)
    /// "SCALE": Node scales horizontally with containing frame
    /// </summary>
    public enum Horizontal { Center, Left, LeftRight, Right, Scale };

    /// <summary>
    /// Vertical constraint as an enum
    /// "TOP": Node is laid out relative to top of the containing frame
    /// "BOTTOM": Node is laid out relative to bottom of the containing frame
    /// "CENTER": Node is vertically centered relative to containing frame
    /// "TOP_BOTTOM": Both top and bottom of node are constrained relative to containing frame
    /// (node stretches with frame)
    /// "SCALE": Node scales vertically with containing frame
    /// </summary>
    public enum Vertical { Bottom, Center, Scale, Top, TopBottom };

    /// <summary>
    /// Type of effect as a string enum
    /// </summary>
    public enum EffectType { BackgroundBlur, DropShadow, InnerShadow, LayerBlur };

    /// <summary>
    /// Type of constraint to apply; string enum with potential values below
    /// "SCALE": Scale by value
    /// "WIDTH": Scale proportionally and set width to value
    /// "HEIGHT": Scale proportionally and set height to value
    /// </summary>
    public enum ConstraintType { Height, Scale, Width };

    /// <summary>
    /// Image type, string enum
    /// </summary>
    public enum Format { Jpg, Png, Svg };

    /// <summary>
    /// Type of paint as a string enum
    /// </summary>
    public enum PaintType { Emoji, GradientAngular, GradientDiamond, GradientLinear, GradientRadial, Image, Solid };

    /// <summary>
    /// Where stroke is drawn relative to the vector outline as a string enum
    /// "INSIDE": draw stroke inside the shape boundary
    /// "OUTSIDE": draw stroke outside the shape boundary
    /// "CENTER": draw stroke centered along the shape boundary
    /// </summary>
    public enum StrokeAlign { Center, Inside, Outside };

    /// <summary>
    /// the type of the node, refer to table below for details
    /// </summary>
    public enum NodeType { Boolean, Canvas, Component, Document, Ellipse, Frame, Group, Instance, Line, Rectangle, RegularPolygon, Slice, Star, Text, Vector };

    /// <summary>
    /// Positioning of grid as a string enum
    /// "MIN": Grid starts at the left or top of the frame
    /// "MAX": Grid starts at the right or bottom of the frame
    /// "CENTER": Grid is center aligned
    /// </summary>
    public enum Alignment { Center, Max, Min };

    /// <summary>
    /// Orientation of the grid as a string enum
    /// "COLUMNS": Vertical grid
    /// "ROWS": Horizontal grid
    /// "GRID": Square grid
    /// </summary>
    public enum Pattern { Columns, Grid, Rows };

    /// <summary>
    /// Horizontal text alignment as string enum
    /// </summary>
    public enum TextAlignHorizontal { Center, Justified, Left, Right };

    /// <summary>
    /// Vertical text alignment as string enum
    /// </summary>
    public enum TextAlignVertical { Bottom, Center, Top };

    public partial class FileResponse
    {
        public static FileResponse FromJson(string json) => JsonConvert.DeserializeObject<FileResponse>(json, QuickType.Converter.Settings);
    }

    public partial class CommentsResponse
    {
        public static CommentsResponse FromJson(string json) => JsonConvert.DeserializeObject<CommentsResponse>(json, QuickType.Converter.Settings);
    }

    public partial class CommentRequest
    {
        public static CommentRequest FromJson(string json) => JsonConvert.DeserializeObject<CommentRequest>(json, QuickType.Converter.Settings);
    }

    public partial class ProjectsResponse
    {
        public static ProjectsResponse FromJson(string json) => JsonConvert.DeserializeObject<ProjectsResponse>(json, QuickType.Converter.Settings);
    }

    public partial class ProjectFilesResponse
    {
        public static ProjectFilesResponse FromJson(string json) => JsonConvert.DeserializeObject<ProjectFilesResponse>(json, QuickType.Converter.Settings);
    }

    static class BlendModeExtensions
    {
        public static BlendMode? ValueForString(string str)
        {
            switch (str)
            {
                case "COLOR": return BlendMode.Color;
                case "COLOR_BURN": return BlendMode.ColorBurn;
                case "COLOR_DODGE": return BlendMode.ColorDodge;
                case "DARKEN": return BlendMode.Darken;
                case "DIFFERENCE": return BlendMode.Difference;
                case "EXCLUSION": return BlendMode.Exclusion;
                case "HARD_LIGHT": return BlendMode.HardLight;
                case "HUE": return BlendMode.Hue;
                case "LIGHTEN": return BlendMode.Lighten;
                case "LINEAR_BURN": return BlendMode.LinearBurn;
                case "LINEAR_DODGE": return BlendMode.LinearDodge;
                case "LUMINOSITY": return BlendMode.Luminosity;
                case "MULTIPLY": return BlendMode.Multiply;
                case "NORMAL": return BlendMode.Normal;
                case "OVERLAY": return BlendMode.Overlay;
                case "PASS_THROUGH": return BlendMode.PassThrough;
                case "SATURATION": return BlendMode.Saturation;
                case "SCREEN": return BlendMode.Screen;
                case "SOFT_LIGHT": return BlendMode.SoftLight;
                default: return null;
            }
        }

        public static BlendMode ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this BlendMode value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case BlendMode.Color: serializer.Serialize(writer, "COLOR"); break;
                case BlendMode.ColorBurn: serializer.Serialize(writer, "COLOR_BURN"); break;
                case BlendMode.ColorDodge: serializer.Serialize(writer, "COLOR_DODGE"); break;
                case BlendMode.Darken: serializer.Serialize(writer, "DARKEN"); break;
                case BlendMode.Difference: serializer.Serialize(writer, "DIFFERENCE"); break;
                case BlendMode.Exclusion: serializer.Serialize(writer, "EXCLUSION"); break;
                case BlendMode.HardLight: serializer.Serialize(writer, "HARD_LIGHT"); break;
                case BlendMode.Hue: serializer.Serialize(writer, "HUE"); break;
                case BlendMode.Lighten: serializer.Serialize(writer, "LIGHTEN"); break;
                case BlendMode.LinearBurn: serializer.Serialize(writer, "LINEAR_BURN"); break;
                case BlendMode.LinearDodge: serializer.Serialize(writer, "LINEAR_DODGE"); break;
                case BlendMode.Luminosity: serializer.Serialize(writer, "LUMINOSITY"); break;
                case BlendMode.Multiply: serializer.Serialize(writer, "MULTIPLY"); break;
                case BlendMode.Normal: serializer.Serialize(writer, "NORMAL"); break;
                case BlendMode.Overlay: serializer.Serialize(writer, "OVERLAY"); break;
                case BlendMode.PassThrough: serializer.Serialize(writer, "PASS_THROUGH"); break;
                case BlendMode.Saturation: serializer.Serialize(writer, "SATURATION"); break;
                case BlendMode.Screen: serializer.Serialize(writer, "SCREEN"); break;
                case BlendMode.SoftLight: serializer.Serialize(writer, "SOFT_LIGHT"); break;
            }
        }
    }

    static class HorizontalExtensions
    {
        public static Horizontal? ValueForString(string str)
        {
            switch (str)
            {
                case "CENTER": return Horizontal.Center;
                case "LEFT": return Horizontal.Left;
                case "LEFT_RIGHT": return Horizontal.LeftRight;
                case "RIGHT": return Horizontal.Right;
                case "SCALE": return Horizontal.Scale;
                default: return null;
            }
        }

        public static Horizontal ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Horizontal value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Horizontal.Center: serializer.Serialize(writer, "CENTER"); break;
                case Horizontal.Left: serializer.Serialize(writer, "LEFT"); break;
                case Horizontal.LeftRight: serializer.Serialize(writer, "LEFT_RIGHT"); break;
                case Horizontal.Right: serializer.Serialize(writer, "RIGHT"); break;
                case Horizontal.Scale: serializer.Serialize(writer, "SCALE"); break;
            }
        }
    }

    static class VerticalExtensions
    {
        public static Vertical? ValueForString(string str)
        {
            switch (str)
            {
                case "BOTTOM": return Vertical.Bottom;
                case "CENTER": return Vertical.Center;
                case "SCALE": return Vertical.Scale;
                case "TOP": return Vertical.Top;
                case "TOP_BOTTOM": return Vertical.TopBottom;
                default: return null;
            }
        }

        public static Vertical ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Vertical value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Vertical.Bottom: serializer.Serialize(writer, "BOTTOM"); break;
                case Vertical.Center: serializer.Serialize(writer, "CENTER"); break;
                case Vertical.Scale: serializer.Serialize(writer, "SCALE"); break;
                case Vertical.Top: serializer.Serialize(writer, "TOP"); break;
                case Vertical.TopBottom: serializer.Serialize(writer, "TOP_BOTTOM"); break;
            }
        }
    }

    static class EffectTypeExtensions
    {
        public static EffectType? ValueForString(string str)
        {
            switch (str)
            {
                case "BACKGROUND_BLUR": return EffectType.BackgroundBlur;
                case "DROP_SHADOW": return EffectType.DropShadow;
                case "INNER_SHADOW": return EffectType.InnerShadow;
                case "LAYER_BLUR": return EffectType.LayerBlur;
                default: return null;
            }
        }

        public static EffectType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this EffectType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case EffectType.BackgroundBlur: serializer.Serialize(writer, "BACKGROUND_BLUR"); break;
                case EffectType.DropShadow: serializer.Serialize(writer, "DROP_SHADOW"); break;
                case EffectType.InnerShadow: serializer.Serialize(writer, "INNER_SHADOW"); break;
                case EffectType.LayerBlur: serializer.Serialize(writer, "LAYER_BLUR"); break;
            }
        }
    }

    static class ConstraintTypeExtensions
    {
        public static ConstraintType? ValueForString(string str)
        {
            switch (str)
            {
                case "HEIGHT": return ConstraintType.Height;
                case "SCALE": return ConstraintType.Scale;
                case "WIDTH": return ConstraintType.Width;
                default: return null;
            }
        }

        public static ConstraintType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ConstraintType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ConstraintType.Height: serializer.Serialize(writer, "HEIGHT"); break;
                case ConstraintType.Scale: serializer.Serialize(writer, "SCALE"); break;
                case ConstraintType.Width: serializer.Serialize(writer, "WIDTH"); break;
            }
        }
    }

    static class FormatExtensions
    {
        public static Format? ValueForString(string str)
        {
            switch (str)
            {
                case "JPG": return Format.Jpg;
                case "PNG": return Format.Png;
                case "SVG": return Format.Svg;
                default: return null;
            }
        }

        public static Format ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Format value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Format.Jpg: serializer.Serialize(writer, "JPG"); break;
                case Format.Png: serializer.Serialize(writer, "PNG"); break;
                case Format.Svg: serializer.Serialize(writer, "SVG"); break;
            }
        }
    }

    static class PaintTypeExtensions
    {
        public static PaintType? ValueForString(string str)
        {
            switch (str)
            {
                case "EMOJI": return PaintType.Emoji;
                case "GRADIENT_ANGULAR": return PaintType.GradientAngular;
                case "GRADIENT_DIAMOND": return PaintType.GradientDiamond;
                case "GRADIENT_LINEAR": return PaintType.GradientLinear;
                case "GRADIENT_RADIAL": return PaintType.GradientRadial;
                case "IMAGE": return PaintType.Image;
                case "SOLID": return PaintType.Solid;
                default: return null;
            }
        }

        public static PaintType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this PaintType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case PaintType.Emoji: serializer.Serialize(writer, "EMOJI"); break;
                case PaintType.GradientAngular: serializer.Serialize(writer, "GRADIENT_ANGULAR"); break;
                case PaintType.GradientDiamond: serializer.Serialize(writer, "GRADIENT_DIAMOND"); break;
                case PaintType.GradientLinear: serializer.Serialize(writer, "GRADIENT_LINEAR"); break;
                case PaintType.GradientRadial: serializer.Serialize(writer, "GRADIENT_RADIAL"); break;
                case PaintType.Image: serializer.Serialize(writer, "IMAGE"); break;
                case PaintType.Solid: serializer.Serialize(writer, "SOLID"); break;
            }
        }
    }

    static class StrokeAlignExtensions
    {
        public static StrokeAlign? ValueForString(string str)
        {
            switch (str)
            {
                case "CENTER": return StrokeAlign.Center;
                case "INSIDE": return StrokeAlign.Inside;
                case "OUTSIDE": return StrokeAlign.Outside;
                default: return null;
            }
        }

        public static StrokeAlign ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this StrokeAlign value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case StrokeAlign.Center: serializer.Serialize(writer, "CENTER"); break;
                case StrokeAlign.Inside: serializer.Serialize(writer, "INSIDE"); break;
                case StrokeAlign.Outside: serializer.Serialize(writer, "OUTSIDE"); break;
            }
        }
    }

    static class NodeTypeExtensions
    {
        public static NodeType? ValueForString(string str)
        {
            switch (str)
            {
                case "BOOLEAN": return NodeType.Boolean;
                case "CANVAS": return NodeType.Canvas;
                case "COMPONENT": return NodeType.Component;
                case "DOCUMENT": return NodeType.Document;
                case "ELLIPSE": return NodeType.Ellipse;
                case "FRAME": return NodeType.Frame;
                case "GROUP": return NodeType.Group;
                case "INSTANCE": return NodeType.Instance;
                case "LINE": return NodeType.Line;
                case "RECTANGLE": return NodeType.Rectangle;
                case "REGULAR_POLYGON": return NodeType.RegularPolygon;
                case "SLICE": return NodeType.Slice;
                case "STAR": return NodeType.Star;
                case "TEXT": return NodeType.Text;
                case "VECTOR": return NodeType.Vector;
                default: return null;
            }
        }

        public static NodeType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this NodeType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case NodeType.Boolean: serializer.Serialize(writer, "BOOLEAN"); break;
                case NodeType.Canvas: serializer.Serialize(writer, "CANVAS"); break;
                case NodeType.Component: serializer.Serialize(writer, "COMPONENT"); break;
                case NodeType.Document: serializer.Serialize(writer, "DOCUMENT"); break;
                case NodeType.Ellipse: serializer.Serialize(writer, "ELLIPSE"); break;
                case NodeType.Frame: serializer.Serialize(writer, "FRAME"); break;
                case NodeType.Group: serializer.Serialize(writer, "GROUP"); break;
                case NodeType.Instance: serializer.Serialize(writer, "INSTANCE"); break;
                case NodeType.Line: serializer.Serialize(writer, "LINE"); break;
                case NodeType.Rectangle: serializer.Serialize(writer, "RECTANGLE"); break;
                case NodeType.RegularPolygon: serializer.Serialize(writer, "REGULAR_POLYGON"); break;
                case NodeType.Slice: serializer.Serialize(writer, "SLICE"); break;
                case NodeType.Star: serializer.Serialize(writer, "STAR"); break;
                case NodeType.Text: serializer.Serialize(writer, "TEXT"); break;
                case NodeType.Vector: serializer.Serialize(writer, "VECTOR"); break;
            }
        }
    }

    static class AlignmentExtensions
    {
        public static Alignment? ValueForString(string str)
        {
            switch (str)
            {
                case "CENTER": return Alignment.Center;
                case "MAX": return Alignment.Max;
                case "MIN": return Alignment.Min;
                default: return null;
            }
        }

        public static Alignment ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Alignment value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Alignment.Center: serializer.Serialize(writer, "CENTER"); break;
                case Alignment.Max: serializer.Serialize(writer, "MAX"); break;
                case Alignment.Min: serializer.Serialize(writer, "MIN"); break;
            }
        }
    }

    static class PatternExtensions
    {
        public static Pattern? ValueForString(string str)
        {
            switch (str)
            {
                case "COLUMNS": return Pattern.Columns;
                case "GRID": return Pattern.Grid;
                case "ROWS": return Pattern.Rows;
                default: return null;
            }
        }

        public static Pattern ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Pattern value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Pattern.Columns: serializer.Serialize(writer, "COLUMNS"); break;
                case Pattern.Grid: serializer.Serialize(writer, "GRID"); break;
                case Pattern.Rows: serializer.Serialize(writer, "ROWS"); break;
            }
        }
    }

    static class TextAlignHorizontalExtensions
    {
        public static TextAlignHorizontal? ValueForString(string str)
        {
            switch (str)
            {
                case "CENTER": return TextAlignHorizontal.Center;
                case "JUSTIFIED": return TextAlignHorizontal.Justified;
                case "LEFT": return TextAlignHorizontal.Left;
                case "RIGHT": return TextAlignHorizontal.Right;
                default: return null;
            }
        }

        public static TextAlignHorizontal ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this TextAlignHorizontal value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case TextAlignHorizontal.Center: serializer.Serialize(writer, "CENTER"); break;
                case TextAlignHorizontal.Justified: serializer.Serialize(writer, "JUSTIFIED"); break;
                case TextAlignHorizontal.Left: serializer.Serialize(writer, "LEFT"); break;
                case TextAlignHorizontal.Right: serializer.Serialize(writer, "RIGHT"); break;
            }
        }
    }

    static class TextAlignVerticalExtensions
    {
        public static TextAlignVertical? ValueForString(string str)
        {
            switch (str)
            {
                case "BOTTOM": return TextAlignVertical.Bottom;
                case "CENTER": return TextAlignVertical.Center;
                case "TOP": return TextAlignVertical.Top;
                default: return null;
            }
        }

        public static TextAlignVertical ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this TextAlignVertical value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case TextAlignVertical.Bottom: serializer.Serialize(writer, "BOTTOM"); break;
                case TextAlignVertical.Center: serializer.Serialize(writer, "CENTER"); break;
                case TextAlignVertical.Top: serializer.Serialize(writer, "TOP"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this FileResponse self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this CommentsResponse self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this CommentRequest self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this ProjectsResponse self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this ProjectFilesResponse self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal class Converter: JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BlendMode) || t == typeof(Horizontal) || t == typeof(Vertical) || t == typeof(EffectType) || t == typeof(ConstraintType) || t == typeof(Format) || t == typeof(PaintType) || t == typeof(StrokeAlign) || t == typeof(NodeType) || t == typeof(Alignment) || t == typeof(Pattern) || t == typeof(TextAlignHorizontal) || t == typeof(TextAlignVertical) || t == typeof(BlendMode?) || t == typeof(Horizontal?) || t == typeof(Vertical?) || t == typeof(EffectType?) || t == typeof(ConstraintType?) || t == typeof(Format?) || t == typeof(PaintType?) || t == typeof(StrokeAlign?) || t == typeof(NodeType?) || t == typeof(Alignment?) || t == typeof(Pattern?) || t == typeof(TextAlignHorizontal?) || t == typeof(TextAlignVertical?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(BlendMode))
                return BlendModeExtensions.ReadJson(reader, serializer);
            if (t == typeof(Horizontal))
                return HorizontalExtensions.ReadJson(reader, serializer);
            if (t == typeof(Vertical))
                return VerticalExtensions.ReadJson(reader, serializer);
            if (t == typeof(EffectType))
                return EffectTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(ConstraintType))
                return ConstraintTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(Format))
                return FormatExtensions.ReadJson(reader, serializer);
            if (t == typeof(PaintType))
                return PaintTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(StrokeAlign))
                return StrokeAlignExtensions.ReadJson(reader, serializer);
            if (t == typeof(NodeType))
                return NodeTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(Alignment))
                return AlignmentExtensions.ReadJson(reader, serializer);
            if (t == typeof(Pattern))
                return PatternExtensions.ReadJson(reader, serializer);
            if (t == typeof(TextAlignHorizontal))
                return TextAlignHorizontalExtensions.ReadJson(reader, serializer);
            if (t == typeof(TextAlignVertical))
                return TextAlignVerticalExtensions.ReadJson(reader, serializer);
            if (t == typeof(BlendMode?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return BlendModeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Horizontal?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return HorizontalExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Vertical?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return VerticalExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(EffectType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return EffectTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(ConstraintType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ConstraintTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Format?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return FormatExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(PaintType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return PaintTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(StrokeAlign?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return StrokeAlignExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(NodeType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return NodeTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Alignment?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return AlignmentExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Pattern?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return PatternExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(TextAlignHorizontal?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TextAlignHorizontalExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(TextAlignVertical?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TextAlignVerticalExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(BlendMode))
            {
                ((BlendMode)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Horizontal))
            {
                ((Horizontal)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Vertical))
            {
                ((Vertical)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(EffectType))
            {
                ((EffectType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(ConstraintType))
            {
                ((ConstraintType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Format))
            {
                ((Format)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(PaintType))
            {
                ((PaintType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(StrokeAlign))
            {
                ((StrokeAlign)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(NodeType))
            {
                ((NodeType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Alignment))
            {
                ((Alignment)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Pattern))
            {
                ((Pattern)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(TextAlignHorizontal))
            {
                ((TextAlignHorizontal)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(TextAlignVertical))
            {
                ((TextAlignVertical)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { 
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
