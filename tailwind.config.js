/** @type {import('tailwindcss').Config} */

let themeConfig = require('../theme.config.js')

const colors = require('tailwindcss/colors')
module.exports = {
    content: ['./input/**/*.{cshtml,html,js}', './theme/**/*.{cshtml,html,js}'],
    theme: {
        fontFamily: {
            heading: ['Montserrat', 'Georgia', 'sans-serif'],
            copy: ['Raleway', 'Helvetica', 'sans-serif']
        },
        extend: {
            margin: {
                'logo-offset-x': themeConfig.logoOffset.x,
                'logo-offset-y': themeConfig.logoOffset.y
            },
            colors: {
                'primary-accent': themeConfig.primaryAccent,
                'secondary-accent': themeConfig.secondaryAccent,
                'retro-white': '#F4E8D2',
                'retro-brown': {
                    lightest: '#897a7e',
                    light: '#3b3436',
                    DEFAULT: '#231F20',
                    dark: '#1D1B1C'
                },
                'retro-black': '#151419'
            },
            typography: (theme) => ({
                DEFAULT: {
                    css: {
                        a: {
                            fontWeight: 600,
                            '&:hover': {
                                color: theme('colors.secondary-accent')
                            },
                            transitionProperty: theme('transitionProperty.colors'),
                            transitionDuration: theme('transitionDuration.150'),
                            textDecoration: 'none'
                        },
                        h2: {
                            marginTop: '1.5em',
                            marginBottom: '0.5em',
                            paddingBottom: '0.25rem',
                            borderBottomWidth: '2px',
                            borderBottomColor: theme('colors.secondary-accent')
                        },
                        code: {
                            '&::before,&::after': {
                                display: 'none'
                            },
                            padding: '0.4rem',
                            background: 'var(--tw-prose-pre-bg)',
                            borderRadius: '0.25rem'
                        },
                        '--tw-prose-body': theme('colors.retro-black'),
                        '--tw-prose-headings': theme('colors.retro-black'),
                        '--tw-prose-links': theme('colors.primary-accent'),
                        '--tw-prose-bullets': theme('colors.secondary-accent'),
                        '--tw-prose-code': theme('colors.secondary-accent'),
                        '--tw-prose-pre-bg': theme('colors.retro-brown.DEFAULT'),
                        '--tw-prose-pre-code': colors.white,
                        '--tw-prose-td-borders': theme('colors.retro-brown.lightest'),
                        '--tw-prose-invert-body': colors.white,
                        '--tw-prose-invert-headings': colors.white,
                        '--tw-prose-invert-links': theme('colors.primary-accent'),
                        '--tw-prose-invert-bullets': theme('colors.secondary-accent'),
                        '--tw-prose-invert-code': theme('colors.secondary-accent'),
                        '--tw-prose-invert-td-borders': theme('colors.retro-brown.light')
                    }
                },
                invert: {
                    css: {
                        a: {
                            '&:hover': {
                                color: theme('colors.secondary-accent')
                            }
                        }
                    }
                }
            }),
            gridTemplateColumns: {
                'main': '360px minmax(0, 1fr)',
            }
        }
    },
    plugins: [
        require('@tailwindcss/typography')
    ]
}
