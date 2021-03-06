pipeline {
    agent any

    stages {
        stage('Prepare') {
            steps {
                echo 'Preparing.'
                //unzip dlls
                sh 'curl https://magico13.net/files/KSP1.12.2.zip -o dlls.zip'
                sh 'unzip dlls.zip'
                sh 'python3 version.py ${BUILD_NUMBER}'
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                sh '/usr/bin/msbuild KCTR.sln /property:Configuration=Release'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                script {
                    env.KCTR_VERSION = sh(returnStdout: true, script: 'cat version.txt').trim()
                }
                
                echo 'Deploying....'
                sh 'mkdir -p GameData/KCTR/Plugins'
                sh 'cp LICENSE GameData/KCTR/LICENSE.txt'
                sh 'cp KCTR.version GameData/KCTR/KCTR.version'
                sh 'cp -r KCTR/bin/Release/KCTR*.dll GameData/KCTR/Plugins/'
                sh 'zip -r KCTR_${KCTR_VERSION}.zip GameData'
                archiveArtifacts artifacts: 'KCTR_*.zip', followSymlinks: false
            }
        }
    }
}