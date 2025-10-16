## Design

This folder contains the visual design assets and a small HTML/CSS prototype used to validate layout, styles and content structure for the Onatrix site.

Contents
 - `Onatrix Design Template.fig` — the master Figma file (source of truth for visual designs, components, and artboards).
 - `src/` — lightweight HTML/CSS prototype folder used for local previews and handoff to development:
	 - pages: `index.html`, `about.html`, `projects.html`, `projectDetails.html`, `services.html`, `serviceDetails.html`, `contact.html`
	 - `css/` — stylesheets: `variables.css`, `reset.css`, `main.css`
	 - `images/` — exported/placeholder images used by the prototype

Purpose
 - Keep the design system and visual language centralized in the Figma file.
 - Provide a runnable HTML/CSS prototype for quick previewing and verification of responsive behavior.
 - Store exported assets and examples for developer handoff.

Previewing the prototype
 - The easiest way to preview is to open `Design/src/index.html` in your browser.
 - From PowerShell you can run:

```powershell
# Open the prototype in your default browser (PowerShell)
ii .\Design\src\index.html
```

 - Alternatively, use the VS Code Live Server extension pointed at the `Design/src` folder for automatic reload while editing.

Design tokens and CSS structure
 - `css/variables.css` contains the project's design tokens (colors, type sizes, spacing). Keep tokens synchronized with the Figma styles.
 - `css/reset.css` normalizes browser defaults.
 - `css/main.css` contains page-level layout, utilities and component styling used by the prototype.

Asset export and naming
 - Export vector assets as SVG where possible (icons, logos).
 - Export raster images at 1x and 2x when needed (e.g., `hero@1x.jpg`, `hero@2x.jpg`) and put them into `src/images/`.
 - Keep filenames lowercase and kebab-cased: `project-thumbnail-01.png`.
 - Optimize assets (SVGO for SVG, and a lossless compressor for PNG/JPEG) before committing.

Updating the design (workflow)
 1. Make visual changes in `Onatrix Design Template.fig` (Figma).
 2. Update or add component styles and tokens in Figma first (colors, typography, spacing).
 3. Export updated assets from Figma and place them into `Design/src/images/` following the naming conventions above.
 4. If layout or markup needs adjustment, update the prototype files under `Design/src/` (HTML and `main.css`) to reflect the intended behavior.
 5. Preview locally (see Previewing the prototype) and verify across breakpoints.
 6. Commit only the exported assets and small prototype adjustments. For major or production-ready front-end work, move changes to the primary application repository or a feature branch.

Contribution notes
 - Keep Figma as the canonical source for colors, spacing and typography.
 - Small prototype fixes (typos, content placeholders, minor layout tweaks) are fine to commit here.
 - For any UI changes that will affect production code, open a design PR with screenshots and update notes; include links to the relevant Figma frames.

Assumptions & notes
 - This README documents only the Design folder and prototype. It assumes `Onatrix Design Template.fig` is stored alongside this README and is the source file used by the design team.
 - The prototype is intentionally simple and not a production build — it's a tool for validating layout, content and visual decisions.

Contact
 - If you have questions about the design, token names or export settings, ask the project designer or leave a comment in the Figma file.

Thank you — keeping designs and tokens in sync between Figma and the prototype saves time during handoff and implementation.
