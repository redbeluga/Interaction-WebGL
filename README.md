# Unity WebGL Revit-Blender Model Test

A small Unity project to evaluate how Revit and Blender models perform when built for WebGL. This repo contains two 3D scenes—one using an Autodesk-exported Revit sample and one using a custom Blender-made restaurant—and measures stability, performance, and simple interactivity in a browser.

---

## 📝 Overview

- **Purpose**: Verify that Revit models can be imported, rendered, and run smoothly in a Unity WebGL build.
- **Scope**: Compare a Revit sample model (Autodesk) against a Blender restaurant model under identical conditions.
- **Key Finding**: Both scenes run at a stable ~100 FPS in Chrome/Edge. The only visual glitch is a flickering artifact on one wall of the Revit model.

---

## 🚀 Getting Started

### Prerequisites

- **Unity** 2021.3 LTS (or newer) with WebGL Build Support
- Git
- A modern WebGL-capable browser (Chrome, Edge, Firefox)

### Clone & Open

```bash
git clone https://github.com/your-username/unity-revit-webgl-test.git
cd unity-revit-webgl-test
