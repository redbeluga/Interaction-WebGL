# Unity WebGL Revit vs. Blender Model Test

A quick Unity project to compare a Revit sample model and a Blender‐made restaurant model in a single WebGL scene. Both models are placed side by side under the same lighting and camera setup to test stability, performance, and basic interaction.

---

## 📝 Overview

- **Purpose**: Validate that a Revit-exported model and a Blender model run smoothly together in a Unity WebGL build.  
- **Scene**: One unified scene (`SampleScene.unity`) containing:
  - The Autodesk Revit sample model  
  - A custom restaurant model from Blender  
- **Key Finding**: Stable ~100 FPS in desktop browsers. The only artifact is a flickering wall on the Revit model.

---

## 🚀 Getting Started

### Prerequisites

- **Unity 6** with **WebGL Build Support**  
- Git  
- A modern WebGL-capable browser (Chrome, Edge, Firefox)

### Clone & Open

```bash
git clone https://github.com/your-username/unity-revit-webgl-test.git
cd unity-revit-webgl-test
